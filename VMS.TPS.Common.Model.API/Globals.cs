// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 21:24:15
// Source DLL: VMS.TPS.Common.Model.API
// Version:    1.0.700.247
// Token:      305b81e210ec4b89
// ===========================================================================

using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using VMS.TPS.Common.Model.Types;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class Globals : Object
    {
        public Globals() { }
        public static void Initialize(ILogger logger, AssemblyName executingAssemblyName) { }
        public static void SetMaximumNumberOfLoggedApiCalls(int apiLogCacheSize) { }
        public static IEnumerable<string> GetLoggedApiCalls()  => default;
        public static void EnableApiAccessTrace() { }
        public static void DisableApiAccessTrace() { }
        public static void AddCustomLogEntry(string message, LogSeverity logSeverity) { }
        public static bool AbortNow { get; set; }
        public static int DefaultMaximumNumberOfLoggedApiCalls { get; set; }
    }
}
