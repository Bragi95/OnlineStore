﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class StorageOutputModel
    {
        public int id { get; set; }
        public int CityId { get; set; }
        public string  CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}