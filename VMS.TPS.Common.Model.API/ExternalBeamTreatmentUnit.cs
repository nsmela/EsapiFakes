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

namespace VMS.TPS.Common.Model.API
{
    public  partial class ExternalBeamTreatmentUnit : ApiDataObject
    {
        public ExternalBeamTreatmentUnit() { }
        public void WriteXml(XmlWriter writer) { }
        public string MachineDepartmentName { get; set; }
        public string MachineModel { get; set; }
        public string MachineModelName { get; set; }
        public string MachineScaleDisplayName { get; set; }
        public TreatmentUnitOperatingLimits OperatingLimits { get; set; }
        public double SourceAxisDistance { get; set; }
    }
}
