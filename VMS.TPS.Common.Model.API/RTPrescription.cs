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
    public  class RTPrescription : ApiDataObject
    {
        public RTPrescription() { }
        public void WriteXml(XmlWriter writer) { }
        public string BolusFrequency { get; set; }
        public string BolusThickness { get; set; }
        public IEnumerable<string> Energies { get; set; }
        public IEnumerable<string> EnergyModes { get; set; }
        public string Gating { get; set; }
        public RTPrescription LatestRevision { get; set; }
        public string Notes { get; set; }
        public Nullable<int> NumberOfFractions { get; set; }
        public IEnumerable<RTPrescriptionOrganAtRisk> OrgansAtRisk { get; set; }
        public string PhaseType { get; set; }
        public RTPrescription PredecessorPrescription { get; set; }
        public int RevisionNumber { get; set; }
        public Nullable<bool> SimulationNeeded { get; set; }
        public string Site { get; set; }
        public string Status { get; set; }
        public IEnumerable<RTPrescriptionTargetConstraints> TargetConstraintsWithoutTargetLevel { get; set; }
        public IEnumerable<RTPrescriptionTarget> Targets { get; set; }
        public string Technique { get; set; }
    }
}
