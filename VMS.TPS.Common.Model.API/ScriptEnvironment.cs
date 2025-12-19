// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 21:15:19
// Source DLL: VMS.TPS.Common.Model.API
// Version:    1.0.700.247
// Token:      305b81e210ec4b89
// ===========================================================================

using System;
using System.Collections.Generic;
using System.Xml;
using VMS.TPS.Common.Model.Types;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace VMS.TPS.Common.Model.API
{
    public  class ScriptEnvironment : Object
    {
        public ScriptEnvironment() { }
        public void ExecuteScript(Assembly scriptAssembly, ScriptContext scriptContext, Window window) { }
        public string ApplicationName { get; set; }
        public string VersionInfo { get; set; }
        public string ApiVersionInfo { get; set; }
        public IEnumerable<ApplicationScript> Scripts { get; set; }
        public IEnumerable<ApplicationPackage> Packages { get; set; }
    }
}
