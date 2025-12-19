// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-19 08:08:01
// Source DLL: VMS.TPS.Common.Model.API
// Version:    1.0.700.247
// Token:      305b81e210ec4b89
// ===========================================================================

using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using VMS.TPS.Common.Model.Types;
using System.Reflection;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class ApplicationScript : ApiDataObject
    {
        public ApplicationScript() { }
        public void WriteXml(XmlWriter writer) { }
        public ApplicationScriptApprovalStatus ApprovalStatus { get; set; }
        public string ApprovalStatusDisplayText { get; set; }
        public AssemblyName AssemblyName { get; set; }
        public Nullable<DateTime> ExpirationDate { get; set; }
        public bool IsReadOnlyScript { get; set; }
        public bool IsWriteableScript { get; set; }
        public string PublisherName { get; set; }
        public ApplicationScriptType ScriptType { get; set; }
        public Nullable<DateTime> StatusDate { get; set; }
        public UserIdentity StatusUserIdentity { get; set; }
    }
}
