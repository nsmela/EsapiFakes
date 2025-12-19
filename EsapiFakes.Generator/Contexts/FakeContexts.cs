using System.Collections.Immutable;

namespace EsapiFakes.Generator.Contexts;

public record AssemblyInfo(
    string Name,
    string Version,
    string PublicKeyToken,
    string FilePath
);

// A streamlined context focused ONLY on identity and members
public record FakeClassContext(
    string Name,                // e.g. "PlanSetup"
    string Namespace,           // e.g. "VMS.TPS.Common.Model.API"
    string BaseClass,           // e.g. "PlanningItem" (Simple string, no wrapper info)
    bool IsStatic,
    bool IsAbstract,
    bool IsSealed,
    bool IsEnum,
    bool IsStruct,
    ImmutableList<string> EnumMembers,
    ImmutableList<FakeMemberContext> Members,
    ImmutableList<FakeClassContext> NestedTypes,
    ImmutableHashSet<string> Usings,
    AssemblyInfo SourceAssembly
);

public record FakeMemberContext(
    string Name,
    string ReturnType,          // Exact return type (e.g. "StructureSet")
    string Parameters,          // e.g. "string id, string name"
    string OriginalSignature,   // e.g. "(string id, string name)"
    bool IsProperty,
    bool IsIndexer,
    bool IsStatic,
    bool HasSetter
);