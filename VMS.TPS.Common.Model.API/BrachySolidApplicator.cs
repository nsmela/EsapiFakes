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
using System.Collections.Generic;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class BrachySolidApplicator : ApiDataObject
    {
        public BrachySolidApplicator() { }
        public void WriteXml(XmlWriter writer) { }
        public string ApplicatorSetName { get; set; }
        public string ApplicatorSetType { get; set; }
        public string Category { get; set; }
        public IEnumerable<Catheter> Catheters { get; set; }
        public int GroupNumber { get; set; }
        public string Note { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public string Summary { get; set; }
        public string UID { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }
    }
}
