// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 21:24:15
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
    public  partial class OptimizationObjective : SerializableObject
    {
        public OptimizationObjective() { }
        public void WriteXml(XmlWriter writer) { }
        public bool Equals(object obj)  => default;
        public int GetHashCode()  => default;
        public OptimizationObjectiveOperator Operator { get; set; }
        public double Priority { get; set; }
        public Structure Structure { get; set; }
        public string StructureId { get; set; }
    }
}
