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

namespace VMS.TPS.Common.Model.API
{
    public  class IonControlPointPair : Object
    {
        public IonControlPointPair() { }
        public void ResizeFinalSpotList(int count) { }
        public void ResizeRawSpotList(int count) { }
        public IonControlPointParameters EndControlPoint { get; set; }
        public IonSpotParametersCollection FinalSpotList { get; set; }
        public double NominalBeamEnergy { get; set; }
        public IonSpotParametersCollection RawSpotList { get; set; }
        public IonControlPointParameters StartControlPoint { get; set; }
        public int StartIndex { get; set; }
    }
}
