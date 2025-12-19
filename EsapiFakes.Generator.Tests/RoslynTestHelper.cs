using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EsapiFakes.Generator.Tests {
    public static class RoslynTestHelper {
        // OLD: For testing strings (Not implemented)
        public static INamedTypeSymbol GetSymbol(string source, string name) { throw new NotImplementedException(); }

        // NEW: For testing the Real DLL
        public static INamedTypeSymbol GetSymbolFromAssembly(string dllPath, string fullyQualifiedName) {
            if (!File.Exists(dllPath))
                throw new FileNotFoundException($"Test dependency not found: {dllPath}");

            var references = new List<MetadataReference>();

            // 1. Core .NET References
            references.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location)); // System.Private.CoreLib
            references.Add(MetadataReference.CreateFromFile(typeof(System.Linq.Enumerable).Assembly.Location)); // System.Linq

            // 2. The Specific Assemblies needed for Structure (WPF + Collections)
            references.Add(MetadataReference.CreateFromFile(typeof(System.Collections.BitArray).Assembly.Location));
            references.Add(MetadataReference.CreateFromFile(typeof(System.Windows.Media.Color).Assembly.Location));
            references.Add(MetadataReference.CreateFromFile(typeof(System.Windows.Media.Media3D.MeshGeometry3D).Assembly.Location));
            references.Add(MetadataReference.CreateFromFile(typeof(System.Windows.Point).Assembly.Location));

            // 3. The Target DLL (Varian API)
            references.Add(MetadataReference.CreateFromFile(dllPath));

            // 4. Varian Types DLL (Dependency of API)
            string libDir = Path.GetDirectoryName(dllPath);
            string typesPath = Path.Combine(libDir, "VMS.TPS.Common.Model.Types.dll");
            if (File.Exists(typesPath)) {
                references.Add(MetadataReference.CreateFromFile(typesPath));
            }

            // Create Compilation
            var compilation = CSharpCompilation.Create(
                "EsapiFakesTestAnalysis",
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            // Find the Symbol
            var symbol = compilation.GetTypeByMetadataName(fullyQualifiedName);

            if (symbol is null) {
                var visitor = new DebugVisitor();
                visitor.Visit(compilation.GlobalNamespace);
                throw new Exception($"Could not find symbol '{fullyQualifiedName}' in loaded assembly.");
            }

            return symbol;
        }

        class DebugVisitor : SymbolVisitor
        {
            public override void VisitNamespace(INamespaceSymbol symbol)
            {
                foreach (var member in symbol.GetMembers())
                {
                    if (member is INamespaceSymbol ns)
                    {
                        ns.Accept(this);
                    }
                    else if (member is INamedTypeSymbol type)
                    {
                        // Print found types to Test Output
                        Console.WriteLine($"Found: {type.ToDisplayString()}");
                    }
                }
            }
        }

        public static INamespaceSymbol GetGlobalNamespace(string dllPath)
        {
            // Re-use the existing loading logic, just return the root namespace
            // (You can copy-paste the reference loading block from GetSymbolFromAssembly here)
            if (!File.Exists(dllPath))
                throw new FileNotFoundException($"DLL not found: {dllPath}");

            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Collections.BitArray).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Windows.Point).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Windows.Media.Color).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Windows.Media.Media3D.MeshGeometry3D).Assembly.Location),
                MetadataReference.CreateFromFile(dllPath)
            };

            // Add Types.dll if present
            string libDir = Path.GetDirectoryName(dllPath);
            string typesPath = Path.Combine(libDir, "VMS.TPS.Common.Model.Types.dll");
            if (File.Exists(typesPath))
                references.Add(MetadataReference.CreateFromFile(typesPath));

            var compilation = CSharpCompilation.Create("Scanner", references: references);

            // Get the Assembly Symbol for the Varian DLL specifically
            var assemblySymbol = compilation.GetAssemblyOrModuleSymbol(references.First(r => (r as PortableExecutableReference).FilePath == dllPath)) as IAssemblySymbol;

            return assemblySymbol.GlobalNamespace;
        }
    }
}