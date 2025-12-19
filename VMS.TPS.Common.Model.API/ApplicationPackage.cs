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
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class ApplicationPackage : ApiDataObject
    {
        public ApplicationPackage() { }
        public void WriteXml(XmlWriter writer) { }
        public ApplicationScriptApprovalStatus ApprovalStatus { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ExpirationDate { get; set; }
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }
        public string PublisherData { get; set; }
        public string PublisherName { get; set; }
    }
}
