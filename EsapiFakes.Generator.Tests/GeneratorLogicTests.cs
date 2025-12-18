using EsapiFakes.Generator.Contexts;
using EsapiFakes.Generator.Services;
using EsapiFakes.Generator.Writers;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EsapiFakes.Generator.Tests {
    [TestFixture]
    public class GeneratorLogicTests {
        private TypeReader _reader;
        private string _esapiDllPath;

        [SetUp]
        public void Setup() {
            // Setup paths (same as before)
            var asmInfo = new AssemblyInfo("VMS.TPS.Common.Model.API", "1.0", "TEST_TOKEN", "path");
            _reader = new TypeReader(asmInfo);

            string startDir = AppContext.BaseDirectory;
            string solutionRoot = FindSolutionRoot(startDir);
            _esapiDllPath = Path.Combine(solutionRoot, "libs", "VMS.TPS.Common.Model.API.dll");
        }

        [Test]
        public void Detects_Application_CreateApplication_As_Static() {
            // Arrange
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, "VMS.TPS.Common.Model.API.Application");

            // Act
            var context = _reader.BuildContext(symbol);
            var createMethod = context.Members.FirstOrDefault(m => m.Name == "CreateApplication");

            // Assert
            Assert.That(createMethod, Is.Not.Null, "Could not find CreateApplication method");
            Assert.That(createMethod.IsStatic, Is.True, "CreateApplication should be static");
            Assert.That(createMethod.ReturnType, Does.Contain("Application"), "Should return Application");
        }

        [Test]
        public void Detects_PlanSetup_Inheritance() {
            // Arrange
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, "VMS.TPS.Common.Model.API.PlanSetup");

            // Act
            var context = _reader.BuildContext(symbol);

            // Assert
            Assert.That(context.BaseClass, Is.EqualTo("PlanningItem"), "PlanSetup should inherit from PlanningItem");
        }

        [Test]
        public void Detects_Enum_Correctly() {
            // Arrange (Use a known Enum)
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, "VMS.TPS.Common.Model.API.PlanSetupApprovalStatus");

            // Act
            var context = _reader.BuildContext(symbol);

            // Assert
            Assert.That(context.IsEnum, Is.True);
            Assert.That(context.EnumMembers, Contains.Item("Unapproved"));
            Assert.That(context.EnumMembers, Contains.Item("TreatApproval"));
        }

        [Test]
        public void Writer_Generates_Valid_Code_For_Structure() {
            // Arrange
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, "VMS.TPS.Common.Model.API.Structure");
            var context = _reader.BuildContext(symbol);

            // Act
            string code = FakeClassWriter.Write(context);

            // Assert
            // 1. Check Header
            Assert.That(code, Does.Contain("// Source DLL: VMS.TPS.Common.Model.API"));

            // 2. Check Usings
            Assert.That(code, Does.Contain("using System.Windows.Media.Media3D;"));
            Assert.That(code, Does.Contain("using System.Windows.Media;"));

            // 3. Check Class Definition
            Assert.That(code, Does.Contain("public  class Structure : ApiDataObject"));

            // 4. Check Property (Read/Write conversion)
            // Real ESAPI: public Color Color { get; }
            // Fake ESAPI: public Color Color { get; set; }
            Assert.That(code, Does.Contain("public Color Color { get; set; }"));
        }

        private string FindSolutionRoot(string path) {
            var dir = new DirectoryInfo(path);
            while (dir != null) {
                if (Directory.Exists(Path.Combine(dir.FullName, "libs"))) return dir.FullName;
                dir = dir.Parent;
            }
            throw new DirectoryNotFoundException("Could not find solution root");
        }
    }
}