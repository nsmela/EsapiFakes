using EsapiFakes.Generator.Contexts;
using EsapiFakes.Generator.Services;
using EsapiFakes.Generator.Writers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Reflection;

namespace EsapiFakes.Generator;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            RunGenerator();
        } catch (Exception ex)
        {
            Console.Error.WriteLine($"Fatal Error: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
        }
    }

    static void RunGenerator()
    {
        // 1. Configure Paths
        string solutionRoot = FindSolutionRoot(AppContext.BaseDirectory);
        string libsFolder = Path.Combine(solutionRoot, "libs");
        string esapiDllPath = Path.Combine(libsFolder, "VMS.TPS.Common.Model.API.dll");

        // Output to the Project Folder of the Fake Assembly
        string outputDir = Path.Combine(solutionRoot, "VMS.TPS.Common.Model.API");

        Console.WriteLine("==============================================");
        Console.WriteLine("           ESAPI FAKE GENERATOR               ");
        Console.WriteLine("==============================================");
        Console.WriteLine($"Input:  {esapiDllPath}");
        Console.WriteLine($"Output: {outputDir}");

        if (!File.Exists(esapiDllPath))
        {
            throw new FileNotFoundException("Could not find Varian DLL.", esapiDllPath);
        }

        // 2. Load DLL & Metadata (Using the robust logic from Unit Tests)
        Console.WriteLine("Loading Assembly and analyzing symbols...");
        var (compilation, symbols, assemblyInfo) = LoadAssemblyAndInfo(esapiDllPath);

        Console.WriteLine($"Target Assembly: {assemblyInfo.Name} ({assemblyInfo.Version})");
        Console.WriteLine($"Token: {assemblyInfo.PublicKeyToken}");

        // 3. Prepare Output Directory
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Clean old .cs files (Keep AssemblyInfo.cs and .csproj)
        var oldFiles = Directory.GetFiles(outputDir, "*.cs");
        foreach (var file in oldFiles)
        {
            if (Path.GetFileName(file).Equals("AssemblyInfo.cs", StringComparison.OrdinalIgnoreCase))
                continue;
            File.Delete(file);
        }

        // 4. Initialize Pipeline
        var typeReader = new TypeReader(assemblyInfo);
        Console.WriteLine($"Found {symbols.Count} types to generate.");

        // 5. Execution Loop
        int count = 0;
        foreach (var symbol in symbols)
        {
            try
            {
                var context = typeReader.BuildContext(symbol);
                string code = FakeClassWriter.Write(context);

                // Handle nested types: Write them to the Parent's file, 
                // or if they are top-level, write them to their own file.
                // Note: BuildContext handles nesting internally, so we only write top-level symbols here.
                if (symbol.ContainingType == null)
                {
                    string fileName = $"{MakeValidFileName(symbol.Name)}.cs";
                    File.WriteAllText(Path.Combine(outputDir, fileName), code);
                    count++;
                }

                if (count % 50 == 0)
                    Console.Write(".");
            } catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] Failed {symbol.Name}: {ex.Message}");
            }
        }

        Console.WriteLine($"\nDone. Generated {count} files.");
    }

    static string FindSolutionRoot(string startPath)
    {
        var dir = new DirectoryInfo(startPath);
        while (dir != null)
        {
            if (dir.GetFiles("*.sln").Any())
                return dir.FullName;
            dir = dir.Parent;
        }
        return Directory.GetCurrentDirectory();
    }

    static string MakeValidFileName(string name)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
            name = name.Replace(c, '_');
        return name;
    }

    // THIS IS THE METHOD WE PROVED WORKS IN THE UNIT TESTS
    static (Compilation, List<INamedTypeSymbol>, AssemblyInfo) LoadAssemblyAndInfo(string path)
    {
        string libDir = Path.GetDirectoryName(path);

        // A. Header Info
        var asmName = AssemblyName.GetAssemblyName(path);
        var tokenBytes = asmName.GetPublicKeyToken();
        string token = tokenBytes == null || tokenBytes.Length == 0
            ? "null"
            : BitConverter.ToString(tokenBytes).Replace("-", "").ToLower();

        var info = new AssemblyInfo(asmName.Name, asmName.Version?.ToString() ?? "0.0.0.0", token, path);

        // B. References (Same list as RoslynTestHelper)
        var references = new List<MetadataReference> {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location), // Core
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location), // Linq
            MetadataReference.CreateFromFile(typeof(System.Collections.BitArray).Assembly.Location), // BitArray
            MetadataReference.CreateFromFile(typeof(System.Windows.Point).Assembly.Location), // WindowsBase
            MetadataReference.CreateFromFile(typeof(System.Windows.Media.Color).Assembly.Location), // PresentationCore
            MetadataReference.CreateFromFile(typeof(System.Windows.Media.Media3D.MeshGeometry3D).Assembly.Location), // PresentationCore
            MetadataReference.CreateFromFile(path) // The API itself
        };

        // Add Types.dll
        string typesPath = Path.Combine(libDir, "VMS.TPS.Common.Model.Types.dll");
        if (File.Exists(typesPath))
            references.Add(MetadataReference.CreateFromFile(typesPath));

        // C. Compilation
        var compilation = CSharpCompilation.Create("EsapiFakesGen", references: references);

        // D. Get Symbols
        var assemblySymbol = compilation.GetAssemblyOrModuleSymbol(references.First(r => (r as PortableExecutableReference).FilePath == path)) as IAssemblySymbol;

        if (assemblySymbol == null)
            throw new Exception("Failed to load Assembly Symbol.");

        var allTypes = GetNamespacesRecursively(assemblySymbol.GlobalNamespace)
            .SelectMany(ns => ns.GetTypeMembers())
            .Where(t => t.DeclaredAccessibility == Microsoft.CodeAnalysis.Accessibility.Public)
            // Exclude nested types from the top-level list (TypeReader handles recursion)
            .Where(t => t.ContainingType == null)
            .Where(t => t.TypeKind == TypeKind.Class || t.TypeKind == TypeKind.Struct || t.TypeKind == TypeKind.Enum || t.TypeKind == TypeKind.Interface)
            .OrderBy(t => t.Name)
            .ToList();

        return (compilation, allTypes, info);
    }

    static IEnumerable<INamespaceSymbol> GetNamespacesRecursively(INamespaceSymbol ns)
    {
        yield return ns;
        foreach (var child in ns.GetNamespaceMembers())
        {
            foreach (var grandChild in GetNamespacesRecursively(child))
                yield return grandChild;
        }
    }
}