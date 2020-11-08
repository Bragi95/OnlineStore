using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class MulticookersOutputModel : GoodsOutputModel
    {
        public double? BowlVolume { get; set; }
        public int? NumberOfOperatingModes { get; set; }
        public bool? RemoteStart { get; set; }
        public string InnerCoating { get; set; }
        public string BodyMaterial { get; set; }
    }
}
