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
    public  partial class RadioactiveSourceModel : ApiDataObject
    {
        public RadioactiveSourceModel() { }
        public void WriteXml(XmlWriter writer) { }
        public VVector ActiveSize { get; set; }
        public double ActivityConversionFactor { get; set; }
        public string CalculationModel { get; set; }
        public double DoseRateConstant { get; set; }
        public double HalfLife { get; set; }
        public string LiteratureReference { get; set; }
        public string Manufacturer { get; set; }
        public string SourceType { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> StatusDate { get; set; }
        public string StatusUserName { get; set; }
    }
}
