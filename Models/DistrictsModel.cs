using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Website.Models
{
	public class DistrictsModel
	{
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string StateName{ get; set; }
    }
}