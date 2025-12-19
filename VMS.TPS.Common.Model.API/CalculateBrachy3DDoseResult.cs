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
using System.Collections.Generic;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class CalculateBrachy3DDoseResult : SerializableObject
    {
        public CalculateBrachy3DDoseResult() { }
        public void WriteXml(XmlWriter writer) { }
        public IEnumerable<string> Errors { get; set; }
        public double RoundedDwellTimeAdjustRatio { get; set; }
        public bool Success { get; set; }
    }
}
