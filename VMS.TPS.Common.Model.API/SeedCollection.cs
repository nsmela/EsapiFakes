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
using System.Windows.Media;
using System.Xml;

namespace VMS.TPS.Common.Model.API
{
    public  class SeedCollection : ApiDataObject
    {
        public SeedCollection() { }
        public void WriteXml(XmlWriter writer) { }
        public IEnumerable<BrachyFieldReferencePoint> BrachyFieldReferencePoints { get; set; }
        public Color Color { get; set; }
        public IEnumerable<SourcePosition> SourcePositions { get; set; }
    }
}
