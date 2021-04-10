using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_AirlineReservation.Models;
using System.Web.Http.Cors;

namespace WebAPI_AirlineReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/RegisterAU")]
    public class RegisterAUController : ApiController
    {

        AirLineDatabaseEntities db = new AirLineDatabaseEntities();

        //Login
        [Route("api/RegisterAU/Login/{UserId}/{pwd}")]
        [HttpGet]
        public string Get(int UserId, string pwd)
        {
            string result = "";
            try
            {
                var data = db.User_Registration.Where(x => x.User_Id == UserId && x.Password == pwd);
                if (data.Count() == 0)
                    result = "Invalid Credentials";
                else
                    result = "Login Successful";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }



        //Register--Insert
        [Route("api/RegisterAU/InsertUser")]
        [HttpPost]
        public bool Post([FromBody] User_Registration ur)
        {
            try
            {
                db.User_Registration.Add(ur);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

    }
}
