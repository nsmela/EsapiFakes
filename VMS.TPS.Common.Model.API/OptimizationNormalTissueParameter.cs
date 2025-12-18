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
    public  class OptimizationNormalTissueParameter : OptimizationParameter
    {
        public OptimizationNormalTissueParameter() { }
        public void WriteXml(XmlWriter writer) { }
        public double DistanceFromTargetBorderInMM { get; set; }
        public double EndDosePercentage { get; set; }
        public double FallOff { get; set; }
        public bool IsAutomatic { get; set; }
        public bool IsAutomaticSbrt { get; set; }
        public bool IsAutomaticSrs { get; set; }
        public double Priority { get; set; }
        public double StartDosePercentage { get; set; }
    }
}
