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
using System.Collections.Generic;
using System.Windows.Media;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class Catheter : ApiDataObject
    {
        public Catheter() { }
        public void WriteXml(XmlWriter writer) { }
        public double GetSourcePosCenterDistanceFromTip(SourcePosition sourcePosition)  => default;
        public double GetTotalDwellTime()  => default;
        public void LinkRefLine(Structure refLine) { }
        public void LinkRefPoint(ReferencePoint refPoint) { }
        public bool SetId(string id, string message)  => default;
        public SetSourcePositionsResult SetSourcePositions(double stepSize, double firstSourcePosition, double lastSourcePosition)  => default;
        public void UnlinkRefLine(Structure refLine) { }
        public void UnlinkRefPoint(ReferencePoint refPoint) { }
        public double ApplicatorLength { get; set; }
        public IEnumerable<BrachyFieldReferencePoint> BrachyFieldReferencePoints { get; set; }
        public int BrachySolidApplicatorPartID { get; set; }
        public int ChannelNumber { get; set; }
        public Color Color { get; set; }
        public double DeadSpaceLength { get; set; }
        public double FirstSourcePosition { get; set; }
        public int GroupNumber { get; set; }
        public double LastSourcePosition { get; set; }
        public VVector[] Shape { get; set; }
        public IEnumerable<SourcePosition> SourcePositions { get; set; }
        public double StepSize { get; set; }
        public BrachyTreatmentUnit TreatmentUnit { get; set; }
    }
}
