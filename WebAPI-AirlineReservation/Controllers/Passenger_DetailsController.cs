using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_AirlineReservation.Models;

namespace WebAPI_AirlineReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Passenger_Details")]
    public class Passenger_DetailsController : ApiController
    {
        AirLineDatabaseEntities db = new AirLineDatabaseEntities();
        //Insert Passenger Details
        [Route("api/Passenger_Details/InsertPassengerDetails")]
        [HttpPost]
        public bool Post([FromBody] Passenger_Details pd)
        {
            try
            {
                db.Passenger_Details.Add(pd);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        //Delete Passenger Details
        [Route("api/Passenger_Details/DeletePassenger/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                var del = db.Passenger_Details.Where(x => x.Passenger_id == id).SingleOrDefault();
                if (del == null)
                {
                    throw new Exception("Id cannot be null");
                }
                else
                {
                    db.Passenger_Details.Remove(del);
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
