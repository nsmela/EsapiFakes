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
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  partial class ApiDataObject : SerializableObject
    {
        public string ToString()  => default;
        public void WriteXml(XmlWriter writer) { }
        public bool Equals(object obj)  => default;
        public int GetHashCode()  => default;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string HistoryUserName { get; set; }
        public string HistoryUserDisplayName { get; set; }
        public DateTime HistoryDateTime { get; set; }
    }
}
