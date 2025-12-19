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
    public  class PlanSum : PlanningItem
    {
        public PlanSum() { }
        public void WriteXml(XmlWriter writer) { }
        public void AddItem(PlanningItem pi) { }
        public void AddItem(PlanningItem pi, PlanSumOperation operation, double planWeight) { }
        public PlanSumOperation GetPlanSumOperation(PlanSetup planSetupInPlanSum)  => default;
        public double GetPlanWeight(PlanSetup planSetupInPlanSum)  => default;
        public void RemoveItem(PlanningItem pi) { }
        public void SetPlanSumOperation(PlanSetup planSetupInPlanSum, PlanSumOperation operation) { }
        public void SetPlanWeight(PlanSetup planSetupInPlanSum, double weight) { }
        public IEnumerable<PlanSumComponent> PlanSumComponents { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PlanSetup> PlanSetups { get; set; }
    }
}
