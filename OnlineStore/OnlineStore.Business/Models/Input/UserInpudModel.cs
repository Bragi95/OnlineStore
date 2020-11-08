using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class UserInpudModel
    {
		public int? Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }		
		public string Password { get; set; }		
		public int? CountryId { get; set; }
		public int? CityId { get; set; }		
	}
}
