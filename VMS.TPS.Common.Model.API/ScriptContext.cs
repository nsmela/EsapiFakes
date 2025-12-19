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
    public  partial class ScriptContext
    {
        public ScriptContext() { }
        public User CurrentUser { get; set; }
        public Course Course { get; set; }
        public Image Image { get; set; }
        public StructureSet StructureSet { get; set; }
        public Calculation Calculation { get; set; }
        public ActiveStructureCodeDictionaries StructureCodes { get; set; }
        public Equipment Equipment { get; set; }
        public Patient Patient { get; set; }
        public PlanSetup PlanSetup { get; set; }
        public ExternalPlanSetup ExternalPlanSetup { get; set; }
        public BrachyPlanSetup BrachyPlanSetup { get; set; }
        public IonPlanSetup IonPlanSetup { get; set; }
        public IEnumerable<PlanSetup> PlansInScope { get; set; }
        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; set; }
        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; set; }
        public IEnumerable<IonPlanSetup> IonPlansInScope { get; set; }
        public IEnumerable<PlanSum> PlanSumsInScope { get; set; }
        public PlanSum PlanSum { get; set; }
        public string ApplicationName { get; set; }
        public string VersionInfo { get; set; }
    }
}
