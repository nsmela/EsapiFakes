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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class StructureCode : SerializableObject
    {
        public StructureCode() { }
        public StructureCodeInfo ToStructureCodeInfo()  => default;
        public bool Equals(StructureCode other)  => default;
        public bool Equals(object obj)  => default;
        public string ToString()  => default;
        public int GetHashCode()  => default;
        public void WriteXml(XmlWriter writer) { }
        public string Code { get; set; }
        public string CodeMeaning { get; set; }
        public string CodingScheme { get; set; }
        public string DisplayName { get; set; }
        public bool IsEncompassStructureCode { get; set; }
    }
}
