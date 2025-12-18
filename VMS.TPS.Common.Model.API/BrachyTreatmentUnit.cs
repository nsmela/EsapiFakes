// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 11:58:22
// Source DLL: VMS.TPS.Common.Model.API
// Version:    1.0.700.247
// Token:      305b81e210ec4b89
// ===========================================================================

using System;
using System.Collections.Generic;
using System.Xml;
using VMS.TPS.Common.Model.Types;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  class BrachyTreatmentUnit : ApiDataObject
    {
        public BrachyTreatmentUnit() { }
        public void WriteXml(XmlWriter writer) { }
        public RadioactiveSource GetActiveRadioactiveSource()  => default;
        public string DoseRateMode { get; set; }
        public double DwellTimeResolution { get; set; }
        public string MachineInterface { get; set; }
        public string MachineModel { get; set; }
        public double MaxDwellTimePerChannel { get; set; }
        public double MaxDwellTimePerPos { get; set; }
        public double MaxDwellTimePerTreatment { get; set; }
        public double MaximumChannelLength { get; set; }
        public int MaximumDwellPositionsPerChannel { get; set; }
        public double MaximumStepSize { get; set; }
        public double MinAllowedSourcePos { get; set; }
        public double MinimumChannelLength { get; set; }
        public double MinimumStepSize { get; set; }
        public int NumberOfChannels { get; set; }
        public double SourceCenterOffsetFromTip { get; set; }
        public string SourceMovementType { get; set; }
        public double StepSizeResolution { get; set; }
    }
}
