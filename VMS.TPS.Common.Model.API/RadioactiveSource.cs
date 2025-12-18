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
    public  class RadioactiveSource : ApiDataObject
    {
        public RadioactiveSource() { }
        public void WriteXml(XmlWriter writer) { }
        public Nullable<DateTime> CalibrationDate { get; set; }
        public bool NominalActivity { get; set; }
        public RadioactiveSourceModel RadioactiveSourceModel { get; set; }
        public string SerialNumber { get; set; }
        public double Strength { get; set; }
    }
}
