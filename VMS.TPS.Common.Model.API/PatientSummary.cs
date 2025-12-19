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

namespace VMS.TPS.Common.Model.API
{
    public  partial class PatientSummary : SerializableObject
    {
        public PatientSummary() { }
        public void WriteXml(XmlWriter writer) { }
        public Nullable<DateTime> CreationDateTime { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }
        public string Id2 { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public string SSN { get; set; }
    }
}
