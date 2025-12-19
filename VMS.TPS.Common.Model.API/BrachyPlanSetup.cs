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
using System.Text;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  partial class BrachyPlanSetup : PlanSetup
    {
        public BrachyPlanSetup() { }
        public void WriteXml(XmlWriter writer) { }
        public Catheter AddCatheter(string catheterId, BrachyTreatmentUnit treatmentUnit, StringBuilder outputDiagnostics, bool appendChannelNumToId, int channelNum)  => default;
        public void AddLocationToExistingReferencePoint(VVector location, ReferencePoint referencePoint) { }
        public ReferencePoint AddReferencePoint(bool target, string id)  => default;
        public DoseProfile CalculateAccurateTG43DoseProfile(VVector start, VVector stop, double[] preallocatedBuffer)  => default;
        public ChangeBrachyTreatmentUnitResult ChangeTreatmentUnit(BrachyTreatmentUnit treatmentUnit, bool keepDoseIntact, List<string> messages)  => default;
        public CalculateBrachy3DDoseResult CalculateTG43Dose()  => default;
        public string ApplicationSetupType { get; set; }
        public BrachyTreatmentTechniqueType BrachyTreatmentTechnique { get; set; }
        public IEnumerable<Catheter> Catheters { get; set; }
        public Nullable<int> NumberOfPdrPulses { get; set; }
        public Nullable<double> PdrPulseInterval { get; set; }
        public IEnumerable<Structure> ReferenceLines { get; set; }
        public IEnumerable<SeedCollection> SeedCollections { get; set; }
        public IEnumerable<BrachySolidApplicator> SolidApplicators { get; set; }
        public string TreatmentTechnique { get; set; }
        public Nullable<DateTime> TreatmentDateTime { get; set; }
    }
}
