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
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class StructureSet : ApiDataObject
    {
        public StructureSet() { }
        public bool AddCouchStructures(string couchModel, PatientOrientation orientation, RailPosition railA, RailPosition railB, Nullable<double> surfaceHU, Nullable<double> interiorHU, Nullable<double> railHU, IReadOnlyList<Structure> addedStructures, bool imageResized, string error)  => default;
        public bool RemoveCouchStructures(IReadOnlyList<string> removedStructureIds, string error)  => default;
        public void WriteXml(XmlWriter writer) { }
        public Structure AddReferenceLine(string name, string id, VVector[] referenceLinePoints)  => default;
        public Structure AddStructure(string dicomType, string id)  => default;
        public Structure AddStructure(StructureCodeInfo code)  => default;
        public bool CanAddCouchStructures(string error)  => default;
        public bool CanAddStructure(string dicomType, string id)  => default;
        public bool CanRemoveCouchStructures(string error)  => default;
        public bool CanRemoveStructure(Structure structure)  => default;
        public StructureSet Copy()  => default;
        public Structure CreateAndSearchBody(SearchBodyParameters parameters)  => default;
        public void Delete() { }
        public SearchBodyParameters GetDefaultSearchBodyParameters()  => default;
        public void RemoveStructure(Structure structure) { }
        public IEnumerable<Structure> Structures { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public IEnumerable<ApplicationScriptLog> ApplicationScriptLogs { get; set; }
        public Image Image { get; set; }
        public Patient Patient { get; set; }
        public Series Series { get; set; }
        public string SeriesUID { get; set; }
        public string UID { get; set; }
    }
}
