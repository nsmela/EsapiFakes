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
    public  partial class SearchBodyParameters : SerializableObject
    {
        public SearchBodyParameters() { }
        public void WriteXml(XmlWriter writer) { }
        public void LoadDefaults() { }
        public bool FillAllCavities { get; set; }
        public bool KeepLargestParts { get; set; }
        public int LowerHUThreshold { get; set; }
        public int MREdgeThresholdHigh { get; set; }
        public int MREdgeThresholdLow { get; set; }
        public int NumberOfLargestPartsToKeep { get; set; }
        public bool PreCloseOpenings { get; set; }
        public double PreCloseOpeningsRadius { get; set; }
        public bool PreDisconnect { get; set; }
        public double PreDisconnectRadius { get; set; }
        public bool Smoothing { get; set; }
        public int SmoothingLevel { get; set; }
    }
}
