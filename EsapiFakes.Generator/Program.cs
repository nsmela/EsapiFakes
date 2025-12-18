using EsapiFakes.Generator.Contexts;
using EsapiFakes.Generator.Services;
using EsapiFakes.Generator.Writers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Reflection;

namespace EsapiFakes.Generator;

class Program {
    static void Main(string[] args) {
        try {
            RunGenerator();
        } catch (Exception ex) {
            Console.Error.WriteLine($"Fatal Error: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
        }
    }

    static void RunGenerator() {
        // 1. Configure Paths
        string solutionRoot = FindSolutionRoot(AppContext.BaseDirectory);
        string libsFolder = Path.Combine(solutionRoot, "libs");
        string esapiDllPath = Path.Combine(libsFolder, "VMS.TPS.Common.Model.API.dll");

        // Output directory is the Project Folder of the Fake Assembly
        string outputDir = Path.Combine(solutionRoot, "VMS.TPS.Common.Model.API");

        Console.WriteLine("==============================================");
        Console.WriteLine("           ESAPI FAKE GENERATOR               ");
        Console.WriteLine("==============================================");
        Console.WriteLine($"Input:  {esapiDllPath}");
        Console.WriteLine($"Output: {outputDir}");

        if (!File.Exists(esapiDllPath)) {
            throw new FileNotFoundException("Could not find Varian DLL.", esapiDllPath);
        }

        // 2. Load DLL & Metadata
        Console.WriteLine("Loading Assembly and analyzing symbols...");
        var (compilation, symbols, assemblyInfo) = LoadAssemblyAndInfo(esapiDllPath);

        Console.WriteLine($"Target Assembly: {assemblyInfo.Name} ({assemblyInfo.Version})");
        Console.WriteLine($"Token: {assemblyInfo.PublicKeyToken}");

        // 3. Prepare Output Directory
        if (!Directory.Exists(outputDir)) {
            Directory.CreateDirectory(outputDir);
        }

        // Cleanup: Delete old .cs files (but keep AssemblyInfo.cs and project files)
        var oldFiles = Directory.GetFiles(outputDir, "*.cs");
        foreach (var file in oldFiles) {
            if (Path.GetFileName(file).Equals("AssemblyInfo.cs", StringComparison.OrdinalIgnoreCase))
                continue;
            File.Delete(file);
        }

        // 4. Initialize Pipeline
        // Pass the assembly info to the reader so it can be added to the Context
        var typeReader = new TypeReader(assemblyInfo);

        Console.WriteLine($"Found {symbols.Count} types to generate.");

        // 5. Execution Loop
        int count = 0;
        foreach (var symbol in symbols) {
            try {
                // A. Build Context (Analyze)
                var context = typeReader.BuildContext(symbol);

                // B. Write Code (Generate)
                string code = FakeClassWriter.Write(context);

                // C. Save File
                string fileName = $"{symbol.Name}.cs";
                File.WriteAllText(Path.Combine(outputDir, fileName), code);

                count++;
                if (count % 10 == 0) Console.Write("."); // Progress bar
            } catch (Exception ex) {
                Console.WriteLine();
                Console.WriteLine($"[ERROR] Failed to generate {symbol.Name}: {ex.Message}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Generation Complete. {count} files created.");
        Console.WriteLine("----------------------------------------------");
    }

    static string FindSolutionRoot(string startPath) {
        var dir = new DirectoryInfo(startPath);
        while (dir != null) {
            if (dir.GetFiles("*.sln").Any()) return dir.FullName;
            dir = dir.Parent;
        }
        return Directory.GetCurrentDirectory();
    }

    static (Compilation, List<INamedTypeSymbol>, AssemblyInfo) LoadAssemblyAndInfo(string path) {
        string libDir = Path.GetDirectoryName(path);

        // --- A. Extract Header Info (Reflection) ---
        var asmName = AssemblyName.GetAssemblyName(path);
        var publicKeyTokenBytes = asmName.GetPublicKeyToken();
        string tokenString = publicKeyTokenBytes == null || publicKeyTokenBytes.Length == 0
            ? "null"
            : BitConverter.ToString(publicKeyTokenBytes).Replace("-", "").ToLower();

        var assemblyInfo = new AssemblyInfo(
            Name: asmName.Name ?? string.Empty,
            Version: asmName.Version?.ToString() ?? "0.0.0.0",
            PublicKeyToken: tokenString,
            FilePath: path
        );

        // --- B. Setup Roslyn Analysis ---
        var references = new List<MetadataReference> {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location), // System.Private.CoreLib
            MetadataReference.CreateFromFile(path) // The Target API
        };

        // 1. Core .NET Types (System.Object, System.String)
        references.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));

        // 2. System.Collections (Fixes BitArray)
        // In .NET 8, BitArray is in System.Collections.NonGeneric
        references.Add(MetadataReference.CreateFromFile(typeof(System.Collections.BitArray).Assembly.Location));

        // 3. System.Linq (Fixes Enumerable, List extensions)
        references.Add(MetadataReference.CreateFromFile(typeof(System.Linq.Enumerable).Assembly.Location));

        // 4. WPF Types (Fixes Color, MeshGeometry3D)
        // WindowsBase (Point, Rect)
        references.Add(MetadataReference.CreateFromFile(typeof(System.Windows.Point).Assembly.Location));
        // PresentationCore (UIElement, Color, MeshGeometry3D)
        references.Add(MetadataReference.CreateFromFile(typeof(System.Windows.UIElement).Assembly.Location));
        // PresentationFramework (Window, Application) - Wrap in try/catch just in case
        try {
            var wpfAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == "PresentationFramework")
                ?? typeof(System.Windows.Window).Assembly;

            references.Add(MetadataReference.CreateFromFile(wpfAssembly.Location));
        } catch { /* Ignore if missing */ }

        // 5. Varian Dependencies
        references.Add(MetadataReference.CreateFromFile(path)); // The API itself
        if (Directory.Exists(libDir)) {
            var typesDll = Path.Combine(libDir, "VMS.TPS.Common.Model.Types.dll");
            if (File.Exists(typesDll))
                references.Add(MetadataReference.CreateFromFile(typesDll));
        }
        // Create Compilation
        var compilation = CSharpCompilation.Create("EsapiFakesAnalysis", references: references);

        // --- C. Find Symbols ---
        // We look for the exact assembly symbol matching our file
        var assemblySymbol = compilation.GetAssemblyOrModuleSymbol(references.First(r =>
                    (r as PortableExecutableReference)?.FilePath == path)) as IAssemblySymbol;

        // Fallback search
        if (assemblySymbol == null) {
            // Fallback: search by name
            assemblySymbol = compilation.References
                .Select(compilation.GetAssemblyOrModuleSymbol)
                .OfType<IAssemblySymbol>()
                .FirstOrDefault(a => a.Name == asmName.Name);
        }

        if (assemblySymbol == null) throw new Exception($"Could not load symbol for assembly: {asmName.Name}");

        // --- D. Filter Types ---
        var allTypes = GetNamespacesRecursively(assemblySymbol.GlobalNamespace)
            .SelectMany(ns => ns.GetTypeMembers())
            .Where(t => t.DeclaredAccessibility == Microsoft.CodeAnalysis.Accessibility.Public)
            .Where(t => t.TypeKind == TypeKind.Class ||
                        t.TypeKind == TypeKind.Struct ||
                        t.TypeKind == TypeKind.Enum ||
                        t.TypeKind == TypeKind.Interface)
            .OrderBy(t => t.Name)
            .ToList();

        return (compilation, allTypes, assemblyInfo);
    }

    static IEnumerable<INamespaceSymbol> GetNamespacesRecursively(INamespaceSymbol ns) {
        yield return ns;
        foreach (var child in ns.GetNamespaceMembers()) {
            foreach (var grandChild in GetNamespacesRecursively(child))
                yield return grandChild;
        }
    }
}