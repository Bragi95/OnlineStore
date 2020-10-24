using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class StorageDto
    {
        public int id { get; set; }
        public CountryDto Country { get; set; }
        public CityDto City { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }  	
    }
}
