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
using System.Collections.Generic;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class IonControlPoint : ControlPoint
    {
        public IonControlPoint() { }
        public void WriteXml(XmlWriter writer) { }
        public IonSpotCollection FinalSpotList { get; set; }
        public IEnumerable<LateralSpreadingDeviceSettings> LateralSpreadingDeviceSettings { get; set; }
        public double NominalBeamEnergy { get; set; }
        public int NumberOfPaintings { get; set; }
        public IEnumerable<RangeModulatorSettings> RangeModulatorSettings { get; set; }
        public IEnumerable<RangeShifterSettings> RangeShifterSettings { get; set; }
        public IonSpotCollection RawSpotList { get; set; }
        public double ScanningSpotSizeX { get; set; }
        public double ScanningSpotSizeY { get; set; }
        public string ScanSpotTuneId { get; set; }
        public double SnoutPosition { get; set; }
    }
}
