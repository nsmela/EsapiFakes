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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class BeamParameters : Object
    {
        public BeamParameters() { }
        public void SetAllLeafPositions(float[,] leafPositions) { }
        public void SetJawPositions(VRect<double> positions) { }
        public IEnumerable<ControlPointParameters> ControlPoints { get; set; }
        public GantryDirection GantryDirection { get; set; }
        public VVector Isocenter { get; set; }
        public double WeightFactor { get; set; }
    }
}
