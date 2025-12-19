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
    public  class ProtocolPhasePrescription : SerializableObject
    {
        public ProtocolPhasePrescription() { }
        public void WriteXml(XmlWriter writer) { }
        public DoseValue TargetTotalDose { get; set; }
        public DoseValue TargetFractionDose { get; set; }
        public DoseValue ActualTotalDose { get; set; }
        public Nullable<bool> TargetIsMet { get; set; }
        public PrescriptionModifier PrescModifier { get; set; }
        public double PrescParameter { get; set; }
        public PrescriptionType PrescType { get; set; }
        public string StructureId { get; set; }
    }
}
