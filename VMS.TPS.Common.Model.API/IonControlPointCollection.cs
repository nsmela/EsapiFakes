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
using System.Collections.Generic;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  class IonControlPointCollection : SerializableObject
    {
        public IonControlPointCollection() { }
        public IEnumerator<IonControlPoint> GetEnumerator()  => default;
        public void WriteXml(XmlWriter writer) { }
        public IonControlPoint this[] { get; set; }
        public int Count { get; set; }
    }
}
