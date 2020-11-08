using OnlineStore.Data.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
	[KnownType(typeof(WasherOutputModel))]
	public class GoodsOutputModel
    {
		public int? Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public CountryOutputModel Country { get; set; }
		public ColorOutputModel Color { get; set; }
		public string YearOfManufacture { get; set; }
		public double? Weight { get; set; }
		public double? PowerConsumption { get; set; }			
		public decimal? Price { get; set; }
	}
}
