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
    public  class PlanSumComponent : ApiDataObject
    {
        public PlanSumComponent() { }
        public void WriteXml(XmlWriter writer) { }
        public string PlanSetupId { get; set; }
        public PlanSumOperation PlanSumOperation { get; set; }
        public double PlanWeight { get; set; }
    }
}
