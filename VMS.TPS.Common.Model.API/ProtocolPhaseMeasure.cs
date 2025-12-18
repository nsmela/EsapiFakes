// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 11:58:23
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
    public  class ProtocolPhaseMeasure : SerializableObject
    {
        public ProtocolPhaseMeasure() { }
        public void WriteXml(XmlWriter writer) { }
        public double TargetValue { get; set; }
        public double ActualValue { get; set; }
        public Nullable<bool> TargetIsMet { get; set; }
        public MeasureModifier Modifier { get; set; }
        public string StructureId { get; set; }
        public MeasureType Type { get; set; }
        public string TypeText { get; set; }
    }
}
