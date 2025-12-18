using EsapiFakes.Generator.Contexts;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace EsapiFakes.Generator.Services;

public class TypeReader {

    public FakeClassContext BuildContext(INamedTypeSymbol symbol) {
        // 1. Inheritance (Just the raw name)
        string baseClassName = string.Empty;
        if (symbol.BaseType is not null &&
            symbol.BaseType.SpecialType != SpecialType.System_Object &&
            symbol.BaseType.SpecialType != SpecialType.System_Enum &&
            symbol.BaseType.SpecialType != SpecialType.System_ValueType) {
            baseClassName = symbol.BaseType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
        }

        // 2. Members (Properties & Methods)
        var members = new List<FakeMemberContext>();

        // Get all public members (Static AND Instance)
        var rawMembers = symbol.GetMembers()
            .Where(m => m.DeclaredAccessibility == Accessibility.Public && !m.IsImplicitlyDeclared);

        foreach (var m in rawMembers) {
            if (m is IPropertySymbol prop) {
                members.Add(new FakeMemberContext(
                    Name: prop.Name,
                    ReturnType: prop.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                    Parameters: "",
                    OriginalSignature: "",
                    IsProperty: true,
                    IsStatic: prop.IsStatic,
                    HasSetter: prop.SetMethod is not null // We will FORCE setters in the fake anyway
                ));
            } else if (m is IMethodSymbol method && method.MethodKind == MethodKind.Ordinary) {
                // Build parameter string: "int a, string b"
                var paramList = string.Join(", ", method.Parameters.Select(p =>
                    $"{p.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} {p.Name}"));

                members.Add(new FakeMemberContext(
                    Name: method.Name,
                    ReturnType: method.ReturnType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                    Parameters: paramList,
                    OriginalSignature: $"({paramList})",
                    IsProperty: false,
                    IsStatic: method.IsStatic,
                    HasSetter: false
                ));
            }
        }

        // 3. Recursion for Nested Types
        var nested = symbol.GetTypeMembers()
            .Where(t => t.DeclaredAccessibility == Accessibility.Public)
            .Select(BuildContext)
            .ToImmutableList();

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
            NestedTypes: nested
        );
    }
}