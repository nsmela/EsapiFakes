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

namespace VMS.TPS.Common.Model.API
{
    public  class Application : SerializableObject
    {
        public Application() { }
        public void Dispose() { }
        public static Application CreateApplication(string username, string password)  => default;
        public static Application CreateApplication()  => default;
        public Patient OpenPatient(PatientSummary patientSummary)  => default;
        public Patient OpenPatientById(string id)  => default;
        public void ClosePatient() { }
        public void SaveModifications() { }
        public void WriteXml(XmlWriter writer) { }
        public User CurrentUser { get; set; }
        public string SiteProgramDataDir { get; set; }
        public IEnumerable<PatientSummary> PatientSummaries { get; set; }
        public Calculation Calculation { get; set; }
        public ActiveStructureCodeDictionaries StructureCodes { get; set; }
        public Equipment Equipment { get; set; }
        public ScriptEnvironment ScriptEnvironment { get; set; }
    }
}
