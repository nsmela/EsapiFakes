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

namespace VMS.TPS.Common.Model.API
{
    public  class MLC : AddOn
    {
        public MLC() { }
        public void WriteXml(XmlWriter writer) { }
        public string ManufacturerName { get; set; }
        public double MinDoseDynamicLeafGap { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
    }
}
