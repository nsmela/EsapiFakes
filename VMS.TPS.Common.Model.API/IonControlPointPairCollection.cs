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

namespace VMS.TPS.Common.Model.API
{
    public  partial class IonControlPointPairCollection
    {
        public IonControlPointPairCollection() { }
        public IEnumerator<IonControlPointPair> GetEnumerator()  => default;
        public List<IonControlPointPair> _collection = default;
        public IonControlPointPair this[int index] => _collection[index];
        public int Count { get; set; }
    }
}
