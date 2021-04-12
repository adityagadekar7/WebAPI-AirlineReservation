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


        //-------Cancel Bookings----------------------------

        //Get booked ticket details by  pnr no
        [Route("api/Dashboard/GetBookedTicketByPnr/{pnr}")]
        [HttpGet]
        //this method gives employee details based on some condition(id)
        public Flight_Reservation Get(int pnr,int test=50000)
        {
            try
            {
                var data = db.Flight_Reservation.Where(x => x.Pnr_no == pnr).FirstOrDefault();
                //var res = db.Flight_Reservation(pnr).ToList();
                if (data == null)
                {
                    throw new Exception("Invalid Ticket Number");
                }
                else
                {
                    return data;
                }


                //return db.ProjectInfoes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Insert into Cancellation Table
        [Route("api/Dashboard/InsertInCancelled")] 
        [HttpPost]
        public bool Post([FromBody] Cancellation c)
        {
            try
            {
                db.Cancellations.Add(c);
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


        ////Delet from Booked Table
        //[Route("api/Dashboard/DeleteFromBooked/{pnr}")]
        //[HttpDelete]
        //public bool Delete(int pnr)
        //{
        //    try
        //    {
        //        var delFlightRes = db.Flight_Reservation.Where(x => x.Pnr_no == pnr).SingleOrDefault();
        //        //var delFlightRes = db.Flight_Reservation.Count(db.Flight_Reservation.Where(x => x.Pnr_no == pnr));
        //        //PassengerDetailsModel pd=
        //        //var psgdet=db.Passenger_Details.Where(x => x.Pnr_no == pnr).FirstOrDefault();
        //        if (delFlightRes == null)
        //        {
        //            throw new Exception("Ticket Number cannot be null");
        //        }
        //        else
        //        {
        //            //var delpsg = db.Passenger_Details.Find(pnr);
        //            //foreach(var x in db.Passenger_Details)
        //            //{
        //            //    var z = db.Passenger_Details.Where(y => y.Pnr_no == pnr);
        //            //    db.Passenger_Details.Remove(z);
        //            //}
        //            //db.Passenger_Details.Remove(delpsg);
        //            db.Flight_Reservation.Remove(delFlightRes);
        //            //db.Passenger_Details.Remove(db.Passenger_Details.Where(x => x.Pnr_no == pnr).SingleOrDefault());
        //            var res = db.SaveChanges();
        //            if (res > 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return false;
        //}


        [Route("api/Dashboard/UpdateBookedTickets/{pnr}")]
        [HttpPut] //Update
        public bool Put(int pnr,[FromBody] Flight_Reservation fr)
        {
            try
            {
                var olddata = db.Flight_Reservation.Where(x => x.Pnr_no == pnr).SingleOrDefault();
                if (olddata == null)
                {
                    throw new Exception("Invalid Ticket Number");
                }
                else
                {
                    olddata.status = fr.status;
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
