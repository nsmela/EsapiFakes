using EsapiFakes.Generator.Contexts;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace EsapiFakes.Generator.Services;

public class TypeReader {

    private readonly AssemblyInfo _sourceInfo;

    // Use MinimallyQualified so the code reads "MeshGeometry3D" not "System.Windows..."
    private static readonly SymbolDisplayFormat _format = SymbolDisplayFormat.MinimallyQualifiedFormat;

    public TypeReader(AssemblyInfo sourceInfo) {
        _sourceInfo = sourceInfo;
    }

    public FakeClassContext BuildContext(INamedTypeSymbol symbol) {
        // 1. Inheritance (Just the raw name)
        string baseClassName = string.Empty;
        var usedNamespaces = new HashSet<string>();

        if (symbol.BaseType is not null
            && symbol.TypeKind != TypeKind.Struct
            && symbol.TypeKind != TypeKind.Enum
            && symbol.BaseType.SpecialType != SpecialType.System_Object
            && symbol.BaseType.SpecialType != SpecialType.System_Enum
            && symbol.BaseType.SpecialType != SpecialType.System_ValueType) {
            baseClassName = symbol.BaseType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
            CollectNamespaces(symbol.BaseType, usedNamespaces);
        }

        // 2. Members (Properties & Methods)
        var members = new List<FakeMemberContext>();

        // Get all public members (Static AND Instance)
        var rawMembers = symbol.GetMembers()
            .Where(m => m.DeclaredAccessibility == Microsoft.CodeAnalysis.Accessibility.Public && !m.IsImplicitlyDeclared);

        foreach (var m in rawMembers) {
            if (m is IPropertySymbol prop) {
                CollectNamespaces(prop.Type, usedNamespaces);

                // FIX: Detect Indexers
                if (prop.IsIndexer)
                {
                    var paramList = string.Join(", ", prop.Parameters.Select(p =>
                        $"{p.Type.ToDisplayString(_format)} {p.Name}"));

                    // Indexers need parameter types' namespaces too
                    foreach (var p in prop.Parameters)
                        CollectNamespaces(p.Type, usedNamespaces);

                    members.Add(new FakeMemberContext(
                        Name: "this", // Indexers are always named "this" in C#
                        ReturnType: prop.Type.ToDisplayString(_format),
                        Parameters: $"[{paramList}]", // Store brackets here for easier writing
                        OriginalSignature: "",
                        IsProperty: true,
                        IsIndexer: true,
                        IsStatic: prop.IsStatic,
                        HasSetter: prop.SetMethod != null
                    ));
                    continue; // Skip the rest of the property processing
                }

                members.Add(new FakeMemberContext(
                    Name: prop.Name,
                    ReturnType: prop.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                    Parameters: "",
                    OriginalSignature: "",
                    IsProperty: true,
                    IsIndexer: false,
                    IsStatic: prop.IsStatic,
                    HasSetter: prop.SetMethod is not null // We will FORCE setters in the fake anyway
                ));
            } else if (m is IMethodSymbol method && method.MethodKind == MethodKind.Ordinary) {
                CollectNamespaces(method.ReturnType, usedNamespaces);

                // Build parameter string: "int a, string b"
                var paramsList = new List<string>();
                foreach (var p in method.Parameters) {
                    CollectNamespaces(p.Type, usedNamespaces);
                    paramsList.Add($"{p.Type.ToDisplayString(_format)} {p.Name}");
                }

                string paramString = string.Join(", ", paramsList);

                members.Add(new FakeMemberContext(
                    Name: method.Name,
                    ReturnType: method.ReturnType.ToDisplayString(_format),
                    Parameters: paramString,
                    OriginalSignature: $"({paramString})",
                    IsProperty: false,
                    IsIndexer: false,
                    IsStatic: method.IsStatic,
                    HasSetter: false
                ));
            }
        }

        // 3. Recursion for Nested Types
        var nested = symbol.GetTypeMembers()
            .Where(t => t.DeclaredAccessibility == Microsoft.CodeAnalysis.Accessibility.Public)
            .Select(BuildContext)
            .ToImmutableList();

        // 4. Cleanup Namespaces
        usedNamespaces.Remove(symbol.ContainingNamespace.ToDisplayString()); // Remove Self
        usedNamespaces.Remove("System"); // Usually included by default
        usedNamespaces.Remove("<global namespace>");

        return new FakeClassContext(
            Name: symbol.Name,
            Namespace: symbol.ContainingNamespace.ToDisplayString(),
            BaseClass: baseClassName,
            IsStatic: symbol.IsStatic,
            IsAbstract: symbol.IsAbstract,
            IsSealed: symbol.IsSealed,
            IsEnum: symbol.TypeKind == TypeKind.Enum,
            IsStruct: symbol.IsValueType && symbol.TypeKind != TypeKind.Enum,
            EnumMembers: symbol.TypeKind == TypeKind.Enum
                ? symbol.GetMembers().OfType<IFieldSymbol>().Select(f => f.Name).ToImmutableList()
                : ImmutableList<string>.Empty,
            Members: members.ToImmutableList(),
            NestedTypes: nested,
            Usings: usedNamespaces.ToImmutableHashSet(),
            SourceAssembly: _sourceInfo
        );
    }

    // Recursively finds namespaces in generics (e.g. List<MeshGeometry3D>)
    private void CollectNamespaces(ITypeSymbol symbol, HashSet<string> namespaces) {
        if (symbol == null || symbol.SpecialType != SpecialType.None) return;

        if (symbol.ContainingNamespace != null && !string.IsNullOrEmpty(symbol.ContainingNamespace.Name)) {
            namespaces.Add(symbol.ContainingNamespace.ToDisplayString());
        }

        if (symbol is INamedTypeSymbol namedType && namedType.IsGenericType) {
            foreach (var arg in namedType.TypeArguments) {
                CollectNamespaces(arg, namespaces);
            }
        }
    }
}