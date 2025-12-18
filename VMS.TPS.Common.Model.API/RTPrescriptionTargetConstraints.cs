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
using System.Collections.Generic;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  class RTPrescriptionTargetConstraints : SerializableObject
    {
        public RTPrescriptionTargetConstraints() { }
        public void WriteXml(XmlWriter writer) { }
        public IEnumerable<RTPrescriptionConstraint> Constraints { get; set; }
        public string TargetId { get; set; }
    }
}
