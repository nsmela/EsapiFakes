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
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class Patient : ApiDataObject
    {
        public Patient() { }
        public void WriteXml(XmlWriter writer) { }
        public Course AddCourse()  => default;
        public StructureSet AddEmptyPhantom(string imageId, PatientOrientation orientation, int xSizePixel, int ySizePixel, double widthMM, double heightMM, int nrOfPlanes, double planeSepMM)  => default;
        public ReferencePoint AddReferencePoint(bool target, string id)  => default;
        public void BeginModifications() { }
        public bool CanAddCourse()  => default;
        public bool CanAddEmptyPhantom(string errorMessage)  => default;
        public bool CanCopyImageFromOtherPatient(Study targetStudy, string otherPatientId, string otherPatientStudyId, string otherPatient3DImageId, string errorMessage)  => default;
        public bool CanModifyData()  => default;
        public bool CanRemoveCourse(Course course)  => default;
        public bool CanRemoveEmptyPhantom(StructureSet structureset, string errorMessage)  => default;
        public StructureSet CopyImageFromOtherPatient(string otherPatientId, string otherPatientStudyId, string otherPatient3DImageId)  => default;
        public StructureSet CopyImageFromOtherPatient(Study targetStudy, string otherPatientId, string otherPatientStudyId, string otherPatient3DImageId)  => default;
        public void RemoveCourse(Course course) { }
        public void RemoveEmptyPhantom(StructureSet structureset) { }
        public IEnumerable<Course> Courses { get; set; }
        public Nullable<DateTime> CreationDateTime { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Department DefaultDepartment { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public string FirstName { get; set; }
        public bool HasModifiedData { get; set; }
        public Hospital Hospital { get; set; }
        public string Id2 { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PrimaryOncologistId { get; set; }
        public string PrimaryOncologistName { get; set; }
        public IEnumerable<ReferencePoint> ReferencePoints { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public string Sex { get; set; }
        public string SSN { get; set; }
        public IEnumerable<StructureSet> StructureSets { get; set; }
        public IEnumerable<Study> Studies { get; set; }
    }
}
