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

namespace VMS.TPS.Common.Model.API
{
    public  class TreatmentUnitOperatingLimits : SerializableObject
    {
        public TreatmentUnitOperatingLimits() { }
        public void WriteXml(XmlWriter writer) { }
        public TreatmentUnitOperatingLimit CollimatorAngle { get; set; }
        public TreatmentUnitOperatingLimit GantryAngle { get; set; }
        public TreatmentUnitOperatingLimit MU { get; set; }
        public TreatmentUnitOperatingLimit PatientSupportAngle { get; set; }
    }
}
