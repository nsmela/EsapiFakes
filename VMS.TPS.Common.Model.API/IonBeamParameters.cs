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

namespace VMS.TPS.Common.Model.API
{
    public  partial class IonBeamParameters : BeamParameters
    {
        public IonBeamParameters() { }
        public IEnumerable<IonControlPointParameters> ControlPoints { get; set; }
        public string PreSelectedRangeShifter1Id { get; set; }
        public string PreSelectedRangeShifter1Setting { get; set; }
        public string PreSelectedRangeShifter2Id { get; set; }
        public string PreSelectedRangeShifter2Setting { get; set; }
        public IonControlPointPairCollection IonControlPointPairs { get; set; }
        public string SnoutId { get; set; }
        public double SnoutPosition { get; set; }
        public Structure TargetStructure { get; set; }
    }
}
