using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
   public  class VacuumCleanerOutputModel : GoodsOutputModel
   {		
		public int? NumberOfOperatingModes { get; set; }
		public double? VolumeOfTheDustContainer { get; set; }
		public double? VolumeOfTheLiquidTank { get; set; }
		public bool? AutomaticCleaning { get; set; }
		public bool? RemoteStart { get; set; }
	}
}
