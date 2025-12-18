using System.Collections.Immutable;

namespace EsapiFakes.Generator.Contexts;

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
    ImmutableList<FakeClassContext> NestedTypes
);

public record FakeMemberContext(
    string Name,
    string ReturnType,          // Exact return type (e.g. "StructureSet")
    string Parameters,          // e.g. "string id, string name"
    string OriginalSignature,   // e.g. "(string id, string name)"
    bool IsProperty,
    bool IsStatic,
    bool HasSetter
);