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
    public  class Block : ApiDataObject
    {
        public Block() { }
        public void WriteXml(XmlWriter writer) { }
        public AddOnMaterial AddOnMaterial { get; set; }
        public bool IsDiverging { get; set; }
        public Point[][] Outline { get; set; }
        public double TransmissionFactor { get; set; }
        public Tray Tray { get; set; }
        public double TrayTransmissionFactor { get; set; }
        public BlockType Type { get; set; }
    }
}
