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
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class RTPrescriptionConstraint : SerializableObject
    {
        public RTPrescriptionConstraint() { }
        public void WriteXml(XmlWriter writer) { }
        public RTPrescriptionConstraintType ConstraintType { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
