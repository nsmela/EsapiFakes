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
    public  class Registration : ApiDataObject
    {
        public Registration() { }
        public void WriteXml(XmlWriter writer) { }
        public VVector InverseTransformPoint(VVector pt)  => default;
        public VVector TransformPoint(VVector pt)  => default;
        public Nullable<DateTime> CreationDateTime { get; set; }
        public string RegisteredFOR { get; set; }
        public string SourceFOR { get; set; }
        public RegistrationApprovalStatus Status { get; set; }
        public Nullable<DateTime> StatusDateTime { get; set; }
        public string StatusUserDisplayName { get; set; }
        public string StatusUserName { get; set; }
        public double[,] TransformationMatrix { get; set; }
        public string UID { get; set; }
    }
}
