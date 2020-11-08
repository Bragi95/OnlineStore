using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
	public class GoodsDto
	{
		public int? Id { get; set; }		
		public string Brand {get;set;}		
		public string Model {get;set;}		
		public CountryDto Country { get; set; }		
		public ColorDto Color { get; set; }
		public DateTime? YearOfManufacture { get; set; }
		public double? Weight  { get; set; }
		public double? PowerConsumption { get; set; }
		public bool? RemoteStart { get; set; }
		public int? NumberOfOperatingModes  { get; set; }
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
