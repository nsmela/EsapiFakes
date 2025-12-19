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
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class FieldReferencePoint : ApiDataObject
    {
        public FieldReferencePoint() { }
        public void WriteXml(XmlWriter writer) { }
        public double EffectiveDepth { get; set; }
        public DoseValue FieldDose { get; set; }
        public bool IsFieldDoseNominal { get; set; }
        public bool IsPrimaryReferencePoint { get; set; }
        public ReferencePoint ReferencePoint { get; set; }
        public VVector RefPointLocation { get; set; }
        public double SSD { get; set; }
    }
}
