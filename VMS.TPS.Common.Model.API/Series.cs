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
    public  partial class Series : ApiDataObject
    {
        public Series() { }
        public void WriteXml(XmlWriter writer) { }
        public void SetImagingDevice(string imagingDeviceId) { }
        public string FOR { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string ImagingDeviceDepartment { get; set; }
        public string ImagingDeviceId { get; set; }
        public string ImagingDeviceManufacturer { get; set; }
        public string ImagingDeviceModel { get; set; }
        public string ImagingDeviceSerialNo { get; set; }
        public SeriesModality Modality { get; set; }
        public Study Study { get; set; }
        public string UID { get; set; }
    }
}
