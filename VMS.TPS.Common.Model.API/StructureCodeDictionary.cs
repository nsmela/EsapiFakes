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
    public  partial class StructureCodeDictionary : Object
    {
        public StructureCodeDictionary() { }
        public bool ContainsKey(string key)  => default;
        public bool TryGetValue(string key, StructureCode value)  => default;
        public IEnumerator<KeyValuePair<string, StructureCode>> GetEnumerator()  => default;
        public string ToString()  => default;
        public string Name { get; set; }
        public string Version { get; set; }
        public IEnumerable<string> Keys { get; set; }
        public IEnumerable<StructureCode> Values { get; set; }
        public int Count { get; set; }
        public StructureCode this[string key] { get; set; }
    }
}
