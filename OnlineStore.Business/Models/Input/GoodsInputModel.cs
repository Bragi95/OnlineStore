using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class GoodsInputModel
    {
		public int? Id { get; set; }		
		public int? TypeId { get; set; }	
		public string Brand { get; set; }	
		public string Model { get; set; }
		public int? CountryId { get; set; }
		public int? ColorId { get; set; }	
		public string YearOfManufacture { get; set; }
		public double? Weight { get; set; }
		public double? PowerConsumption { get; set; }
		public bool? RemoteStart { get; set; }
		public int? NumberOfOperatingModes { get; set; }
		public double? VolumeOfTheDustContainer { get; set; }
		public double? VolumeOfTheLiquidTank { get; set; }
		public bool? AutomaticCleaning { get; set; }
		public string BodyMaterial { get; set; }
		public bool? TemperatureMaintenance { get; set; }
		public double? ChamberVolume { get; set; }
		public string InnerCoating { get; set; }
		public double? BowlVolume { get; set; }
		public string TypeOfHeating { get; set; }
		public double? MaxLoading { get; set; }
		public double? TheVolumeOfTheDrum { get; set; }
		public bool? DryerMode { get; set; }
		public decimal? Price { get; set; }
	}
}
