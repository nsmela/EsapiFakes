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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public  class Structure : ApiDataObject
    {
        public Structure() { }
        public void WriteXml(XmlWriter writer) { }
        public void AddContourOnImagePlane(VVector[] contour, int z) { }
        public SegmentVolume And(SegmentVolume other)  => default;
        public SegmentVolume AsymmetricMargin(AxisAlignedMargins margins)  => default;
        public bool CanConvertToHighResolution()  => default;
        public bool CanEditSegmentVolume(string errorMessage)  => default;
        public bool CanSetAssignedHU(string errorMessage)  => default;
        public void ClearAllContoursOnImagePlane(int z) { }
        public void ConvertDoseLevelToStructure(Dose dose, DoseValue doseLevel) { }
        public void ConvertToHighResolution() { }
        public bool GetAssignedHU(double huValue)  => default;
        public VVector[][] GetContoursOnImagePlane(int z)  => default;
        public int GetNumberOfSeparateParts()  => default;
        public VVector[] GetReferenceLinePoints()  => default;
        public SegmentProfile GetSegmentProfile(VVector start, VVector stop, BitArray preallocatedBuffer)  => default;
        public bool IsPointInsideSegment(VVector point)  => default;
        public SegmentVolume Margin(double marginInMM)  => default;
        public SegmentVolume Not()  => default;
        public SegmentVolume Or(SegmentVolume other)  => default;
        public bool ResetAssignedHU()  => default;
        public void SetAssignedHU(double huValue) { }
        public SegmentVolume Sub(SegmentVolume other)  => default;
        public void SubtractContourOnImagePlane(VVector[] contour, int z) { }
        public SegmentVolume Xor(SegmentVolume other)  => default;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public IEnumerable<StructureApprovalHistoryEntry> ApprovalHistory { get; set; }
        public VVector CenterPoint { get; set; }
        public Color Color { get; set; }
        public string DicomType { get; set; }
        public bool HasCalculatedPlans { get; set; }
        public bool HasSegment { get; set; }
        public bool IsApproved { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsHighResolution { get; set; }
        public bool IsTarget { get; set; }
        public MeshGeometry3D MeshGeometry { get; set; }
        public int ROINumber { get; set; }
        public SegmentVolume SegmentVolume { get; set; }
        public StructureCode StructureCode { get; set; }
        public IEnumerable<StructureCodeInfo> StructureCodeInfos { get; set; }
        public double Volume { get; set; }
    }
}
