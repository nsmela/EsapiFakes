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
using System.Text;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class Course : ApiDataObject
    {
        public Course() { }
        public PlanSum CreatePlanSum(IEnumerable<PlanningItem> planningItems, Image image)  => default;
        public ExternalPlanSetup AddExternalPlanSetup(StructureSet structureSet, Structure targetStructure, ReferencePoint primaryReferencePoint, IEnumerable<ReferencePoint> additionalReferencePoints)  => default;
        public BrachyPlanSetup AddBrachyPlanSetup(StructureSet structureSet, Structure targetStructure, ReferencePoint primaryReferencePoint, DoseValue dosePerFraction, BrachyTreatmentTechniqueType brachyTreatmentTechnique, IEnumerable<ReferencePoint> additionalReferencePoints)  => default;
        public IonPlanSetup AddIonPlanSetup(StructureSet structureSet, Structure targetStructure, ReferencePoint primaryReferencePoint, string patientSupportDeviceId, IEnumerable<ReferencePoint> additionalReferencePoints)  => default;
        public void WriteXml(XmlWriter writer) { }
        public BrachyPlanSetup AddBrachyPlanSetup(StructureSet structureSet, DoseValue dosePerFraction, BrachyTreatmentTechniqueType brachyTreatmentTechnique)  => default;
        public ExternalPlanSetup AddExternalPlanSetup(StructureSet structureSet)  => default;
        public ExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(StructureSet structureSet, ExternalPlanSetup verifiedPlan)  => default;
        public IonPlanSetup AddIonPlanSetup(StructureSet structureSet, string patientSupportDeviceId)  => default;
        public IonPlanSetup AddIonPlanSetupAsVerificationPlan(StructureSet structureSet, string patientSupportDeviceId, IonPlanSetup verifiedPlan)  => default;
        public bool CanAddPlanSetup(StructureSet structureSet)  => default;
        public bool CanRemovePlanSetup(PlanSetup planSetup)  => default;
        public BrachyPlanSetup CopyBrachyPlanSetup(BrachyPlanSetup sourcePlan, StringBuilder outputDiagnostics)  => default;
        public BrachyPlanSetup CopyBrachyPlanSetup(BrachyPlanSetup sourcePlan, StructureSet structureset, StringBuilder outputDiagnostics)  => default;
        public PlanSetup CopyPlanSetup(PlanSetup sourcePlan)  => default;
        public PlanSetup CopyPlanSetup(PlanSetup sourcePlan, Image targetImage, StringBuilder outputDiagnostics)  => default;
        public PlanSetup CopyPlanSetup(PlanSetup sourcePlan, Image targetImage, Registration registration, StringBuilder outputDiagnostics)  => default;
        public PlanSetup CopyPlanSetup(PlanSetup sourcePlan, StructureSet structureset, StringBuilder outputDiagnostics)  => default;
        public bool IsCompleted()  => default;
        public void RemovePlanSetup(PlanSetup planSetup) { }
        public void RemovePlanSum(PlanSum planSum) { }
        public string Id { get; set; }
        public string Comment { get; set; }
        public IEnumerable<ExternalPlanSetup> ExternalPlanSetups { get; set; }
        public IEnumerable<BrachyPlanSetup> BrachyPlanSetups { get; set; }
        public IEnumerable<IonPlanSetup> IonPlanSetups { get; set; }
        public CourseClinicalStatus ClinicalStatus { get; set; }
        public Nullable<DateTime> CompletedDateTime { get; set; }
        public IEnumerable<Diagnosis> Diagnoses { get; set; }
        public string Intent { get; set; }
        public Patient Patient { get; set; }
        public IEnumerable<PlanSetup> PlanSetups { get; set; }
        public IEnumerable<PlanSum> PlanSums { get; set; }
        public Nullable<DateTime> StartDateTime { get; set; }
        public IEnumerable<TreatmentPhase> TreatmentPhases { get; set; }
        public IEnumerable<TreatmentSession> TreatmentSessions { get; set; }
    }
}
