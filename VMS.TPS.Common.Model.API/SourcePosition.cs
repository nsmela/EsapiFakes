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
    public  class SourcePosition : ApiDataObject
    {
        public SourcePosition() { }
        public void WriteXml(XmlWriter writer) { }
        public double DwellTime { get; set; }
        public Nullable<bool> DwellTimeLock { get; set; }
        public double NominalDwellTime { get; set; }
        public RadioactiveSource RadioactiveSource { get; set; }
        public double[,] Transform { get; set; }
        public VVector Translation { get; set; }
    }
}
