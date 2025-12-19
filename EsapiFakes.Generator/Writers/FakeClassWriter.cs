using System.Text;
using EsapiFakes.Generator.Contexts;

namespace EsapiFakes.Generator.Writers;

public static class FakeClassWriter {
    public static string Write(FakeClassContext ctx) {
        var sb = new StringBuilder();

        // --- HEADER BLOCK ---
        sb.AppendLine("// ===========================================================================");
        sb.AppendLine("// ESAPI FAKE GENERATOR");
        sb.AppendLine("// ===========================================================================");
        sb.AppendLine($"// Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine($"// Source DLL: {ctx.SourceAssembly.Name}");
        sb.AppendLine($"// Version:    {ctx.SourceAssembly.Version}");
        sb.AppendLine($"// Token:      {ctx.SourceAssembly.PublicKeyToken}");
        sb.AppendLine("// ===========================================================================");
        sb.AppendLine();

        // Standard Usings
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Windows;");
        sb.AppendLine("using System.Xml;");
        sb.AppendLine("using VMS.TPS.Common.Model.Types;");

        // Dynamic Usings (Collected from TypeReader)
        // Sort them for clean output
        foreach (var ns in ctx.Usings.OrderBy(x => x))
        {
            if (ns != "System.Windows") // Avoid duplicate
                sb.AppendLine($"using {ns};");
        }

        sb.AppendLine();
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
        string classMod = ctx.IsStruct ? "struct" : "class";
        string inheritance = string.IsNullOrEmpty(ctx.BaseClass) ? "" : $" : {ctx.BaseClass}";

        // We force 'partial' so users can extend these fakes manually if needed
        sb.AppendLine($"{indent}public {staticMod} partial {classMod} {ctx.Name}{inheritance}");
        sb.AppendLine($"{indent}{{");

        // 2. Constructor (Force a public parameterless one for easy instantiation)
        if (!ctx.IsStatic && !ctx.IsStruct && !ctx.IsAbstract) {
            sb.AppendLine($"{indent}    public {ctx.Name}() {{ }}");
        }

        // 3. Members
        foreach (var m in ctx.Members) {
            string mod = m.IsStatic ? "public static" : "public";

            if (m.IsProperty) {
                if (m.IsIndexer)
                {
                    // Indexer syntax: public Beam this[string id] { get; set; }
                    // Note: m.Parameters contains "[string id]" from TypeReader
                    sb.AppendLine($"{indent}    {mod} {m.ReturnType} this{m.Parameters} {{ get; set; }}");
                } else
                {
                    // Standard Property
                    sb.AppendLine($"{indent}    {mod} {m.ReturnType} {m.Name} {{ get; set; }}");
                }
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