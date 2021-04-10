using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_AirlineReservation.Models;
using System.Web.Http.Cors;
//Controller for -- User Dashboard--Booked,Cancelled Tickets,payment related functions

namespace WebAPI_AirlineReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Dashboard")]

    public class DashboardController : ApiController
    {

        AirLineDatabaseEntities db = new AirLineDatabaseEntities();

        [Route("api/Dashboard/GetBookedTickets/{id}")]
        [HttpGet]
        public IEnumerable<sp_BookedTickets_Result> Get(int? id)
        {
            try
            {
                var res = db.sp_BookedTickets(id).ToList();
                if (res == null)
                {
                    throw new Exception("NO Tickets booked");
                }
                else
                {
                    return db.sp_BookedTickets(id).ToList();
                }


                //return db.ProjectInfoes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("api/Dashboard/GetCancelledTickets/{id}")]
        [HttpGet]
        public IEnumerable<sp_CancelledTickets_Result> Get(int id) //trial used because same parameter type error for get
        {
            try
            {
                var res = db.sp_CancelledTickets(id).ToList();
                if (res == null)
                {
                    throw new Exception("No Tickets booked");
                }
                else
                {
                    return db.sp_CancelledTickets(id).ToList();
                }


                //return db.ProjectInfoes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
