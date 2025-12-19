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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class DVHData : SerializableObject
    {
        public DVHData() { }
        public void WriteXml(XmlWriter writer) { }
        public double Coverage { get; set; }
        public DVHPoint[] CurveData { get; set; }
        public DoseValue MaxDose { get; set; }
        public VVector MaxDosePosition { get; set; }
        public DoseValue MeanDose { get; set; }
        public DoseValue MedianDose { get; set; }
        public DoseValue MinDose { get; set; }
        public VVector MinDosePosition { get; set; }
        public double SamplingCoverage { get; set; }
        public double StdDev { get; set; }
        public double Volume { get; set; }
    }
}
