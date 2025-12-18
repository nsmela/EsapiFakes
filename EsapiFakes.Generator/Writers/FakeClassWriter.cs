using System.Text;
using EsapiFakes.Generator.Contexts;

namespace EsapiFakes.Generator.Writers;

public static class FakeClassWriter {
    public static string Write(FakeClassContext ctx) {
        var sb = new StringBuilder();

        // Standard Usings
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using VMS.TPS.Common.Model.Types;"); // Real Types DLL
        sb.AppendLine("");
        sb.AppendLine($"namespace {ctx.Namespace}");
        sb.AppendLine("{");

        WriteType(sb, ctx, "    ");

        sb.AppendLine("}");
        return sb.ToString();
    }

    private static void WriteType(StringBuilder sb, FakeClassContext ctx, string indent) {
        // 1. Signature
        if (ctx.IsEnum) {
            sb.AppendLine($"{indent}public enum {ctx.Name}");
            sb.AppendLine($"{indent}{{");
            foreach (var mem in ctx.EnumMembers) { sb.AppendLine($"{indent}    {mem},"); }
            sb.AppendLine($"{indent}}}");
            return;
        }

        string staticMod = ctx.IsStatic ? "static" : "";
        // We REMOVE 'sealed' so we can inherit in tests if we really want to, 
        // but keeping it 'public' is enough.
        string classMod = ctx.IsStruct ? "struct" : "class";
        string inheritance = string.IsNullOrEmpty(ctx.BaseClass) ? "" : $" : {ctx.BaseClass}";

        sb.AppendLine($"{indent}public {staticMod} {classMod} {ctx.Name}{inheritance}");
        sb.AppendLine($"{indent}{{");

        // 2. Constructor (Force a public parameterless one for easy instantiation)
        if (!ctx.IsStatic && !ctx.IsStruct && !ctx.IsAbstract) {
            sb.AppendLine($"{indent}    public {ctx.Name}() {{ }}");
        }

        // 3. Members
        foreach (var m in ctx.Members) {
            string mod = m.IsStatic ? "public static" : "public";

            if (m.IsProperty) {
                // TURN READ-ONLY INTO READ-WRITE for setting up tests
                sb.AppendLine($"{indent}    {mod} {m.ReturnType} {m.Name} {{ get; set; }}");
            } else {
                // Methods return default
                string returnDefault = m.ReturnType == "void" ? "" : " => default;";
                string body = m.ReturnType == "void" ? "{ }" : returnDefault;
                sb.AppendLine($"{indent}    {mod} {m.ReturnType} {m.Name}{m.OriginalSignature} {body}");
            }
        }

        // 4. Nested Types
        foreach (var nested in ctx.NestedTypes) {
            WriteType(sb, nested, indent + "    ");
        }

        sb.AppendLine($"{indent}}}");
    }
}