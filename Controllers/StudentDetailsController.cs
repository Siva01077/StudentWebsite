using Student_Website.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Student_Website.Controllers
{
    public class StudentDetailsController : Controller
    {
        // GET: StudentDetails
        
        public ActionResult Home()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult States()
        {
            return View();
        }
     
        private bool  Insert(StateModel state)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "INSERT INTO State(StateName) values(@StateName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StateName", state.StateName);
            int rowseffected = cmd.ExecuteNonQuery();
               return rowseffected > 0;

        }
        [HttpPost]
        public ActionResult States(StateModel obj)
        {
            if (ModelState.IsValid)
            {
                bool rowinserted = Insert(obj);
                return Json(new { success = rowinserted }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult GetStatelist()
        {
                string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
               SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string querystring = "Select * from State";
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                List<StateModel> Statelist = new List<StateModel>();

                while (rdr.Read())
                {
                    StateModel registration = new StateModel();
                    registration.StateID = Convert.ToInt32(rdr["StateID"]);
                    registration.StateName = Convert.ToString(rdr["StateName"]);

                    Statelist.Add(registration);
                }

                return PartialView("_pStatelist", Statelist);
            }

        [HttpGet]
        public ActionResult Districts()
        {
            return View();
        }
        private bool DistInsert(DistrictsModel  district)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "INSERT INTO District(StateName,DistrictName, StateID) values(@StateName,@DistrictName,@StateID)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StateName", district.StateName);
            cmd.Parameters.AddWithValue("@DistrictName", district.DistrictName);
            cmd.Parameters.AddWithValue("@StateID", district.StateID);

            int rowseffected = cmd.ExecuteNonQuery();
            return rowseffected > 0;

        }
        [HttpPost]
        public ActionResult Districts(DistrictsModel obj)
        {
            if (ModelState.IsValid)
            {
                bool rowinserted = DistInsert(obj);
                return Json(new { success = rowinserted }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult GetDistrictlist()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string querystring = "Select * from District";
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<DistrictsModel> districtlist = new List<DistrictsModel>();

            while (rdr.Read())
            {
                DistrictsModel registration = new DistrictsModel();
                registration.DistrictID = Convert.ToInt32(rdr["DistrictID"]);
                registration.StateName = Convert.ToString(rdr["StateName"]);
                registration.DistrictName = Convert.ToString(rdr["DistrictName"]);

                districtlist.Add(registration);
            }

            return PartialView("_pDistrictlist", districtlist);
        }

        [HttpGet]
        public JsonResult GetStateNameById(int stateId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT StateName FROM State WHERE StateID = @StateID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StateID", stateId);
                SqlDataReader reader = cmd.ExecuteReader();
             
                if(reader.Read())
                {
                
                  string StateName  = Convert.ToString(reader["StateName"]);
                  return Json(new { StateName = StateName }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { StateName = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Cities()
        {
            return View();
        }
        private bool CityInsert(CitiesModel city)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "INSERT INTO City(CityName,DistrictName) values(@CityName,@DistrictName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DistrictName", city.DistrictName);
            cmd.Parameters.AddWithValue("@CityName", city.CityName);
            int rowseffected = cmd.ExecuteNonQuery();
            return rowseffected > 0;

        }
        [HttpPost]
        public ActionResult Cities(CitiesModel obj)
        {
            if (ModelState.IsValid)
            {
                bool rowinserted = CityInsert(obj);
                return Json(new { success = rowinserted }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult GetCitieslist()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string querystring = "Select * from City";
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<CitiesModel> citylist = new List<CitiesModel>();

            while (rdr.Read())
            {
                CitiesModel registration = new CitiesModel();
                registration.CityID = Convert.ToInt32(rdr["CityID"]);
                registration.CityName = Convert.ToString(rdr["CityName"]);
                registration.DistrictName = Convert.ToString(rdr["DistrictName"]);

                citylist.Add(registration);
            }

            return PartialView("_pCitylist", citylist);
        }

        [HttpGet]
        public JsonResult GetDistrictNameById(int DistrictID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DistrictName FROM District WHERE DistrictID = @DistrictID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    string DistrictName = Convert.ToString(reader["DistrictName"]);
                    return Json(new { DistrictName = DistrictName }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { DistrictName = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult StudentReg()
        {
            PopulateStates();
            return View();
        }
        private bool Insert(StudentRegModel obj)
        {
            
                string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Student_Reg(StudentName, Email, Phone, Gender,Address,StateID,DistrictID,CityID) " +
                                   "VALUES (@StudentName,@Email,@Phone,@Gender,@Address,@State,@District,@City)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentName", obj.StudentName);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Phone", obj.Phone);

                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                   
                    cmd.Parameters.AddWithValue("@State", obj.StateID);
                    cmd.Parameters.AddWithValue("@District", obj.DistrictID);
                    cmd.Parameters.AddWithValue("@City", obj.CityID);

                    int rowcount = cmd.ExecuteNonQuery();
                    return rowcount > 0;
                }
            
            
        }

       
        [HttpPost]
        public ActionResult StudentReg(StudentRegModel obj)
        {
            if (ModelState.IsValid)
            {
                
                    bool isInserted = Insert(obj);
                    return Json(new { success = isInserted }, JsonRequestBehavior.AllowGet);
                
            }

            return View(obj);
        }
        [HttpGet]
        public ActionResult GetStudentlist()
        {
            
                string connectionString = @"Data Source=DELL;Initial Catalog=employeeregistration;User Id=sa;Password=Siva@0107";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string querystring = @"select R.StudentId,
                                              R.StudentName,
                                              R.Email,
                                              R.Phone,
                                               R.Address,
                                              R.Gender,
                                              S.StateName ,
                                              D.DistrictName,
                                              C.CityName from Student_Reg R
                                       join State S on S.StateID= R.StateID
                                       join District D on D.DistrictID= R.DistrictID
                                       join City C on C.CityID= R.CityID";
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                List<StudentRegModel> Employeelist = new List<StudentRegModel>();

                while (rdr.Read())
                {
                    StudentRegModel registration = new StudentRegModel();
                registration.StudentId = Convert.ToInt32(rdr["StudentId"]);
                registration.StudentName = Convert.ToString(rdr["StudentName"]);
                    registration.Email = Convert.ToString(rdr["Email"]);
                    registration.Phone = Convert.ToInt64(rdr["Phone"]);
                   
                    registration.Address = Convert.ToString(rdr["Address"]);
                    registration.Gender = Convert.ToString(rdr["Gender"]);
                registration.StateName = Convert.ToString(rdr["StateName"]);
                registration.DistrictName = Convert.ToString(rdr["DistrictName"]);
                registration.CityName = Convert.ToString(rdr["CityName"]);

                Employeelist.Add(registration);
                }

                return PartialView("_pstudentlist", Employeelist);
            }

        private void PopulateStates()
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=employeeregistration;User Id=sa;Password=Siva@0107";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM State";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    List<StateModel> statelist = new List<StateModel>();
                    while (rdr.Read())
                    {
                        StateModel obj = new StateModel();

                        obj.StateID = Convert.ToInt32(rdr["StateID"]);
                        obj.StateName = Convert.ToString(rdr["StateName"]);

                        statelist.Add(obj);
                    }
                    ViewBag.States = new SelectList(statelist,"StateID","StateName");
                }
            }
        }

        [HttpGet]
        public JsonResult GetStateslist()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string querystring = "SELECT StateID, StateName FROM State";
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                List<StateModel> stateList = new List<StateModel>();

                while (rdr.Read())
                {
                    StateModel state = new StateModel();
                    state.StateID = Convert.ToInt32(rdr["StateID"]);
                    state.StateName = Convert.ToString(rdr["StateName"]);
                    stateList.Add(state);

                }

                return Json(stateList, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        
        public JsonResult GetDistrictslist(int StateID) // Now accepts StateName
        {
            List<DistrictsModel> districts = new List<DistrictsModel>();
            string connectionString = @"Data Source=DELL;Initial Catalog=employeeregistration;User Id=sa;Password=Siva@0107";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT DistrictID,StateID, DistrictName FROM District WHERE StateID = @StateID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StateID", StateID);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DistrictsModel obj = new DistrictsModel();
                    obj.DistrictID = Convert.ToInt32(rdr["DistrictID"]);
                    obj.StateID = Convert.ToInt32(rdr["StateID"]);

                    obj.DistrictName = Convert.ToString(rdr["DistrictName"]);
                    districts.Add(obj);
                }
            }

            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCitylist(string DistrictId)
        
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string querystring = "SELECT * FROM City where DistrictName=@DistrictName";
                SqlCommand cmd = new SqlCommand(querystring, con);
                cmd.Parameters.AddWithValue("@DistrictName", DistrictId);
                SqlDataReader rdr = cmd.ExecuteReader();
                List<CitiesModel> citylist = new List<CitiesModel>();

                while (rdr.Read())
                {
                    CitiesModel city = new CitiesModel();
                    city.CityID = Convert.ToInt32(rdr["CityID"]);
                    city.DistrictName = Convert.ToString(rdr["DistrictName"]);
                    city.CityName = Convert.ToString(rdr["CityName"]);
                    citylist.Add(city);

                }

                return Json(citylist, JsonRequestBehavior.AllowGet);
            }
        }
    }
}