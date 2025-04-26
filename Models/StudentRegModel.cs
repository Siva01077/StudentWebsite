using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Website.Models
{
	public class StudentRegModel
	{
		public string StudentName { get; set; }
		public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public int StudentId { get; set; }
        public string Gender { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
}