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
    public  class DVHEstimationModelSummary : SerializableObject
    {
        public DVHEstimationModelSummary() { }
        public void WriteXml(XmlWriter writer) { }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsTrained { get; set; }
        public string ModelDataVersion { get; set; }
        public ParticleType ModelParticleType { get; set; }
        public Guid ModelUID { get; set; }
        public string Name { get; set; }
        public int Revision { get; set; }
        public string TreatmentSite { get; set; }
    }
}
