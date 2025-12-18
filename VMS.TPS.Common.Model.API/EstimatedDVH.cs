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
    public  class EstimatedDVH : ApiDataObject
    {
        public EstimatedDVH() { }
        public void WriteXml(XmlWriter writer) { }
        public DVHPoint[] CurveData { get; set; }
        public PlanSetup PlanSetup { get; set; }
        public string PlanSetupId { get; set; }
        public Structure Structure { get; set; }
        public string StructureId { get; set; }
        public DoseValue TargetDoseLevel { get; set; }
        public DVHEstimateType Type { get; set; }
    }
}
