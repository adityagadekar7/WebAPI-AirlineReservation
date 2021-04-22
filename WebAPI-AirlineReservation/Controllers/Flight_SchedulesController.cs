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
    [Route("api/Flight_Schedules")]
    public class Flight_SchedulesController : ApiController
    {
        
        AirlineDBEntities db = new AirlineDBEntities();

        [Route("api/Flight_Schedules/InsertFlight")]
        [HttpPost]
        public bool Post([FromBody] Flight_Schedules fs)
        {
            try
            {
                db.Flight_Schedules.Add(fs);
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


        [Route("api/Flight_Schedules/GetAllFlights")]
        [HttpGet]  //Get all flight Details
        public IEnumerable<sp_GetAllFlightDetails_Result> Get()
        {
            try
            {
                var FlightDetails=db.sp_GetAllFlightDetails();
                return FlightDetails;
                //var details = db.Flight_Schedules;
                //if (details == null)
                //{
                //    throw new Exception("Flight Details Empty");
                //}
                //else
                //{
                //return details;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("api/Flight_Schedules/DeleteFlight/{id}")]
        [HttpDelete]  //delete
        public bool Delete(int id)
        {
            try
            {
                var del = db.Flight_Schedules.Where(x => x.Flight_Number == id).SingleOrDefault();
                if (del == null)
                {
                    throw new Exception("Id cannot be null");
                }
                else
                {
                    db.Flight_Schedules.Remove(del);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
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
