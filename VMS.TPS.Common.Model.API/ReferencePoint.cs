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
using System.Text;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class ReferencePoint : ApiDataObject
    {
        public ReferencePoint() { }
        public void WriteXml(XmlWriter writer) { }
        public bool AddLocation(Image Image, double x, double y, double z, StringBuilder errorHint)  => default;
        public bool ChangeLocation(Image Image, double x, double y, double z, StringBuilder errorHint)  => default;
        public VVector GetReferencePointLocation(Image Image)  => default;
        public VVector GetReferencePointLocation(PlanSetup planSetup)  => default;
        public bool HasLocation(PlanSetup planSetup)  => default;
        public bool RemoveLocation(Image Image, StringBuilder errorHint)  => default;
        public string Id { get; set; }
        public DoseValue DailyDoseLimit { get; set; }
        public DoseValue SessionDoseLimit { get; set; }
        public DoseValue TotalDoseLimit { get; set; }
    }
}
