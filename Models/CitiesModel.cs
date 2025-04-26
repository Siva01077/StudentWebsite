using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Website.Models
{
	public class CitiesModel
	{
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName{ get; set; }
        public string CityName{ get; set; }
    }
}