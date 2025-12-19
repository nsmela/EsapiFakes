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
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class Hospital : ApiDataObject
    {
        public Hospital() { }
        public void WriteXml(XmlWriter writer) { }
        public Nullable<DateTime> CreationDateTime { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public string Location { get; set; }
    }
}
