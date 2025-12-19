// ===========================================================================
// ESAPI FAKE GENERATOR
// ===========================================================================
// Generated: 2025-12-18 21:24:15
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
    public  partial class Beam : ApiDataObject
    {
        public Beam() { }
        public void AddBolus(Bolus bolus) { }
        public bool RemoveBolus(Bolus bolus)  => default;
        public void WriteXml(XmlWriter writer) { }
        public void AddBolus(string bolusId) { }
        public bool AddFlatteningSequence()  => default;
        public void ApplyParameters(BeamParameters beamParams) { }
        public Dictionary<int, double> CalculateAverageLeafPairOpenings()  => default;
        public bool CanSetOptimalFluence(Fluence fluence, string message)  => default;
        public double CollimatorAngleToUser(double val)  => default;
        public int CountSubfields()  => default;
        public Image CreateOrReplaceDRR(DRRCalculationParameters parameters)  => default;
        public void FitArcOptimizationApertureToCollimatorJaws() { }
        public void FitCollimatorToStructure(FitToStructureMargins margins, Structure structure, bool useAsymmetricXJaws, bool useAsymmetricYJaws, bool optimizeCollimatorRotation) { }
        public void FitMLCToOutline(Point[][] outline) { }
        public void FitMLCToOutline(Point[][] outline, bool optimizeCollimatorRotation, JawFitting jawFit, OpenLeavesMeetingPoint olmp, ClosedLeavesMeetingPoint clmp) { }
        public void FitMLCToStructure(Structure structure) { }
        public void FitMLCToStructure(FitToStructureMargins margins, Structure structure, bool optimizeCollimatorRotation, JawFitting jawFit, OpenLeavesMeetingPoint olmp, ClosedLeavesMeetingPoint clmp) { }
        public double GantryAngleToUser(double val)  => default;
        public double GetCAXPathLengthInBolus(Bolus bolus)  => default;
        public BeamParameters GetEditableParameters()  => default;
        public Fluence GetOptimalFluence()  => default;
        public VVector GetSourceLocation(double gantryAngle)  => default;
        public double GetSourceToBolusDistance(Bolus bolus)  => default;
        public Point[][] GetStructureOutlines(Structure structure, bool inBEV)  => default;
        public string JawPositionsToUserString(VRect<double> val)  => default;
        public double PatientSupportAngleToUser(double val)  => default;
        public bool RemoveBolus(string bolusId)  => default;
        public bool RemoveFlatteningSequence()  => default;
        public void SetOptimalFluence(Fluence fluence) { }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public MetersetValue Meterset { get; set; }
        public int BeamNumber { get; set; }
        public Applicator Applicator { get; set; }
        public double ArcLength { get; set; }
        public ArcOptimizationAperture ArcOptimizationAperture { get; set; }
        public bool AreControlPointJawsMoving { get; set; }
        public double AverageSSD { get; set; }
        public BeamTechnique BeamTechnique { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
        public IEnumerable<Bolus> Boluses { get; set; }
        public IEnumerable<BeamCalculationLog> CalculationLogs { get; set; }
        public double CollimatorRotation { get; set; }
        public string CollimatorRotationAsString { get; set; }
        public Compensator Compensator { get; set; }
        public ControlPointCollection ControlPoints { get; set; }
        public Nullable<DateTime> CreationDateTime { get; set; }
        public BeamDose Dose { get; set; }
        public int DoseRate { get; set; }
        public double DosimetricLeafGap { get; set; }
        public EnergyMode EnergyMode { get; set; }
        public string EnergyModeDisplayName { get; set; }
        public IEnumerable<FieldReferencePoint> FieldReferencePoints { get; set; }
        public GantryDirection GantryDirection { get; set; }
        public bool HasAllMLCLeavesClosed { get; set; }
        public bool IsGantryExtended { get; set; }
        public bool IsGantryExtendedAtStopAngle { get; set; }
        public bool IsImagingTreatmentField { get; set; }
        public bool IsIMRT { get; set; }
        public VVector IsocenterPosition { get; set; }
        public bool IsSetupField { get; set; }
        public double MetersetPerGy { get; set; }
        public MLC MLC { get; set; }
        public MLCPlanType MLCPlanType { get; set; }
        public double MLCTransmissionFactor { get; set; }
        public string MotionCompensationTechnique { get; set; }
        public string MotionSignalSource { get; set; }
        public double NormalizationFactor { get; set; }
        public string NormalizationMethod { get; set; }
        public PlanSetup Plan { get; set; }
        public double PlannedSSD { get; set; }
        public Image ReferenceImage { get; set; }
        public string SetupNote { get; set; }
        public SetupTechnique SetupTechnique { get; set; }
        public double SSD { get; set; }
        public double SSDAtStopAngle { get; set; }
        public Technique Technique { get; set; }
        public string ToleranceTableLabel { get; set; }
        public IEnumerable<Tray> Trays { get; set; }
        public double TreatmentTime { get; set; }
        public ExternalBeamTreatmentUnit TreatmentUnit { get; set; }
        public IEnumerable<Wedge> Wedges { get; set; }
        public double WeightFactor { get; set; }
    }
}
