// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 11:58:22
// Source DLL: VMS.TPS.Common.Model.API
// Version:    1.0.700.247
// Token:      305b81e210ec4b89
// ===========================================================================

using System;
using System.Collections.Generic;
using System.Xml;
using VMS.TPS.Common.Model.Types;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  class ApplicationScriptLog : ApiDataObject
    {
        public ApplicationScriptLog() { }
        public void WriteXml(XmlWriter writer) { }
        public string CourseId { get; set; }
        public string PatientId { get; set; }
        public string PlanSetupId { get; set; }
        public string PlanUID { get; set; }
        public ApplicationScript Script { get; set; }
        public string ScriptFullName { get; set; }
        public string StructureSetId { get; set; }
        public string StructureSetUID { get; set; }
    }
}
