using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class ElectricKettleOutputModel : GoodsOutputModel
    {
        public bool? TemperatureMaintenance { get; set; }
        public bool? RemoteStart { get; set; }
        public string BodyMaterial { get; set; }
        public string InnerCoating { get; set; }
    }
}
