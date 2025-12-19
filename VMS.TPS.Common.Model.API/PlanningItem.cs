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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class PlanningItem : ApiDataObject
    {
        public PlanningItem() { }
        public void WriteXml(XmlWriter writer) { }
        public List<ClinicalGoal> GetClinicalGoals()  => default;
        public DVHData GetDVHCumulativeData(Structure structure, DoseValuePresentation dosePresentation, VolumePresentation volumePresentation, double binWidth)  => default;
        public DoseValue GetDoseAtVolume(Structure structure, double volume, VolumePresentation volumePresentation, DoseValuePresentation requestedDosePresentation)  => default;
        public double GetVolumeAtDose(Structure structure, DoseValue dose, VolumePresentation requestedVolumePresentation)  => default;
        public Course Course { get; set; }
        public Nullable<DateTime> CreationDateTime { get; set; }
        public PlanningItemDose Dose { get; set; }
        public DoseValuePresentation DoseValuePresentation { get; set; }
        public StructureSet StructureSet { get; set; }
        public IEnumerable<Structure> StructuresSelectedForDvh { get; set; }
    }
}
