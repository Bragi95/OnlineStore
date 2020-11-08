using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class WasherOutputModel : GoodsOutputModel
    {
        public double? MaxLoading { get; set; }
		public double? TheVolumeOfTheDrum { get; set; }
		public bool? DryerMode { get; set; }
        public bool? RemoteStart { get; set; }
        public double? ChamberVolume { get; set; }
        public int? NumberOfOperatingModes { get; set; }
    }
}
