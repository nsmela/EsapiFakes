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
    public  class ControlPoint : SerializableObject
    {
        public ControlPoint() { }
        public void WriteXml(XmlWriter writer) { }
        public Beam Beam { get; set; }
        public double CollimatorAngle { get; set; }
        public double GantryAngle { get; set; }
        public int Index { get; set; }
        public VRect<double> JawPositions { get; set; }
        public float[,] LeafPositions { get; set; }
        public double MetersetWeight { get; set; }
        public double PatientSupportAngle { get; set; }
        public double TableTopLateralPosition { get; set; }
        public double TableTopLongitudinalPosition { get; set; }
        public double TableTopVerticalPosition { get; set; }
    }
}
