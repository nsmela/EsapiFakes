using EsapiFakes.Generator.Contexts;
using EsapiFakes.Generator.Services;
using EsapiFakes.Generator.Writers;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        public void Debug_Find_Nested_Enum()
        {
            // 1. Find the Parent Class first (TradeoffExplorationContext)
            var parentName = "VMS.TPS.Common.Model.API.TradeoffExplorationContext";
            var parentSymbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, parentName);

            Assert.That(parentSymbol, Is.Not.Null, $"Could not find Parent Class: {parentName}");

            Console.WriteLine($"\n--- Inspecting {parentSymbol.Name} ---");

            // 2. Get all Nested Types (Classes, Enums, Structs)
            var nestedTypes = parentSymbol.GetTypeMembers();

            if (nestedTypes.Length == 0)
            {
                Console.WriteLine("This class has NO nested types.");
            }

            foreach (var type in nestedTypes)
            {
                Console.WriteLine($"Found Nested Type: {type.Name} (IsEnum: {type.TypeKind == TypeKind.Enum})");
            }
            Console.WriteLine("----------------------------------\n");

            // 3. Fail intentionally so we can see the output
            if (nestedTypes.Length == 0)
            {
                Assert.Fail("The parent class exists, but has no nested types to test!");
            }

            // If we found one, let's try to build context from the first enum we found
            var firstEnum = nestedTypes.FirstOrDefault(t => t.TypeKind == TypeKind.Enum);
            if (firstEnum != null)
            {
                var context = _reader.BuildContext(firstEnum);
                Assert.That(context.IsEnum, Is.True);
                Console.WriteLine($"Successfully built context for: {context.Name}");
            }
        }

        [Test]
        public void Detects_Any_Nested_Type_Correctly()
        {
            // 1. Scan the Assembly for ANY class that has a public nested type
            var globalNamespace = RoslynTestHelper.GetGlobalNamespace(_esapiDllPath);

            INamedTypeSymbol parentClass = null;
            INamedTypeSymbol nestedType = null;

            foreach (var type in GetAllTypes(globalNamespace))
            {
                var nested = type.GetTypeMembers()
                    .FirstOrDefault(t => t.DeclaredAccessibility == Microsoft.CodeAnalysis.Accessibility.Public);

                if (nested != null)
                {
                    parentClass = type;
                    nestedType = nested;
                    if (nestedType.Name == "Algorithm")
                    { continue; }
                    break; // Found one!
                }
            }

            if (nestedType is null)
            {
                Assert.Ignore("This version of ESAPI does not appear to have any public nested types in the API assembly. Skipping test.");
                return;
            }

            Console.WriteLine($"Testing with Real Example: {parentClass.Name} + {nestedType.Name}");

            // 2. Act
            var context = _reader.BuildContext(nestedType);

            // 3. Assert
            Assert.That(context.Name, Is.EqualTo(nestedType.Name));

            // Verify it knows its parent context if we were generating full files, 
            // but for the Unit Unit context, we just ensure it parsed successfully.
            Assert.That(context.Namespace, Is.EqualTo(parentClass.ContainingNamespace.ToDisplayString()));
        }

        // Helper to flatten the namespace tree
        private IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol root)
        {
            foreach (var member in root.GetMembers())
            {
                if (member is INamespaceSymbol ns)
                {
                    foreach (var t in GetAllTypes(ns))
                        yield return t;
                } else if (member is INamedTypeSymbol type)
                {
                    yield return type;
                }
            }
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

        [Test]
        public void Detects_Nested_Enum_In_API()
        {
            // 1. Arrange
            // Note the '+' syntax for Nested Types in Metadata lookups
            var enumName = "VMS.TPS.Common.Model.API.TradeoffExplorationContext+TradeoffPlanGenerationIntermediateDoseMode";
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, enumName);

            // 2. Act
            var context = _reader.BuildContext(symbol);

            // 3. Assert
            Assert.That(context.IsEnum, Is.True, "Should be identified as an Enum");
            Assert.That(context.Name, Is.EqualTo("TradeoffPlanGenerationIntermediateDoseMode"));
            // Verify it found members (exact names depend on version, but 'UseIntermediateDose' is standard)
            Assert.That(context.EnumMembers, Is.Not.Empty);
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