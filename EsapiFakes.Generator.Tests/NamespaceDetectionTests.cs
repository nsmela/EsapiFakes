using EsapiFakes.Generator.Contexts;
using EsapiFakes.Generator.Services;
using NUnit.Framework;
using System;
using System.IO;

namespace EsapiFakes.Generator.Tests {
    [TestFixture]
    public class NamespaceDetectionTests {
        private TypeReader _reader;
        private string _esapiDllPath;

        [SetUp]
        public void Setup() {
            // Dummy assembly info for the reader
            _reader = new TypeReader(new AssemblyInfo("Test", "1.0", "null", "path"));

            // Locate the DLL relative to the Test Execution folder
            // Usually: EsapiFakes.Generator.Tests/bin/Debug/net8.0-windows/
            // Libs:    ../../../../libs/
            string startDir = AppContext.BaseDirectory;
            string solutionRoot = FindSolutionRoot(startDir);
            _esapiDllPath = Path.Combine(solutionRoot, "libs", "VMS.TPS.Common.Model.API.dll");
        }

        [Test]
        public void Real_Structure_Class_Detects_All_Namespaces() {
            // 1. Get the REAL symbol from the DLL
            var symbol = RoslynTestHelper.GetSymbolFromAssembly(_esapiDllPath, "VMS.TPS.Common.Model.API.Structure");

            // 2. Run the Reader
            var context = _reader.BuildContext(symbol);

            // 3. Assert - These specific usings MUST be present

            // For 'public Color Color { get; }'
            Assert.That(context.Usings, Contains.Item("System.Windows.Media"),
                "Failed to detect Color namespace");

            // For 'public MeshGeometry3D MeshGeometry { get; }'
            Assert.That(context.Usings, Contains.Item("System.Windows.Media.Media3D"),
                "Failed to detect MeshGeometry3D namespace");

            // For 'BitArray' usages (e.g. methods or props)
            Assert.That(context.Usings, Contains.Item("System.Collections"),
                "Failed to detect BitArray namespace");

            // For VVector etc.
            Assert.That(context.Usings, Contains.Item("VMS.TPS.Common.Model.Types"),
                "Failed to detect Varian Types namespace");
        }

        private string FindSolutionRoot(string path) {
            var dir = new DirectoryInfo(path);
            while (dir != null) {
                if (Directory.Exists(Path.Combine(dir.FullName, "libs")))
                    return dir.FullName;
                dir = dir.Parent;
            }
            throw new DirectoryNotFoundException("Could not find solution root with 'libs' folder.");
        }
    }
}