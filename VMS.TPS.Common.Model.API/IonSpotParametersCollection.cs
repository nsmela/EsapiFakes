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
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class IonSpotParametersCollection : SerializableObject
    {
        public IonSpotParametersCollection() { }
        public IEnumerator<IonSpotParameters> GetEnumerator()  => default;
        public void WriteXml(XmlWriter writer) { }
        public IonSpotParameters this[int index] { get; set; }
        public int Count { get; set; }
    }
}
