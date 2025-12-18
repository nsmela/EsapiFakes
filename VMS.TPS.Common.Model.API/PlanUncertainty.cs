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
using System.Collections.Generic;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class PlanUncertainty : ApiDataObject
    {
        public PlanUncertainty() { }
        public void WriteXml(XmlWriter writer) { }
        public DVHData GetDVHCumulativeData(Structure structure, DoseValuePresentation dosePresentation, VolumePresentation volumePresentation, double binWidth)  => default;
        public IEnumerable<BeamUncertainty> BeamUncertainties { get; set; }
        public double CalibrationCurveError { get; set; }
        public string DisplayName { get; set; }
        public Dose Dose { get; set; }
        public VVector IsocenterShift { get; set; }
        public PlanUncertaintyType UncertaintyType { get; set; }
    }
}
