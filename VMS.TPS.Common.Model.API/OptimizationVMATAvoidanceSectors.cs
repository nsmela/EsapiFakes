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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class OptimizationVMATAvoidanceSectors : OptimizationParameter
    {
        public OptimizationVMATAvoidanceSectors() { }
        public void WriteXml(XmlWriter writer) { }
        public OptimizationAvoidanceSector AvoidanceSector1 { get; set; }
        public OptimizationAvoidanceSector AvoidanceSector2 { get; set; }
        public Beam Beam { get; set; }
        public bool IsValid { get; set; }
        public string ValidationError { get; set; }
    }
}
