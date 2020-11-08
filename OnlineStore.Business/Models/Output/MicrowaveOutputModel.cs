using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class MicrowaveOutputModel : GoodsOutputModel
    {
        public double? ChamberVolume { get; set; }
        public string TypeOfHeating { get; set; }
        public string BodyMaterial { get; set; }
        public int? NumberOfOperatingModes { get; set; }
        public bool? RemoteStart { get; set; }    
    }
}
