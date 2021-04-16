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
    [Route("api/Booking")]

    public class BookingController : ApiController
    {
        AirLineDatabaseEntities db = new AirLineDatabaseEntities();
        

        //    [Route("api/Booking/InsertAll")]
        //    [HttpPost]

        //    public string Post([FromBody] Flight_Reservation fr, Passenger_Details psg, Payment_Details pay )
        //    {
        //        try
        //        {
        //            db.Flight_Reservation.Add(fr);
        //            var res = db.SaveChanges();
        //            if (res > 0)
        //            {
        //                db.Passenger_Details.Add(psg);
        //                var res1 = db.SaveChanges();
        //                if (res1 > 0)
        //                {
        //                    db.Payment_Details.Add(pay);
        //                    var res2 = db.SaveChanges();
        //                    if (res2 > 0)
        //                    {
        //                        return ("Inserted All");
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return ("Failed");
        //    }


        [Route("api/Booking/InsertFlightReservation")]
        [HttpPost]
        public bool Post([FromBody] Flight_Reservation c)
        {
            try
            {
                
                db.Flight_Reservation.Add(c);
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

        [Route("api/Booking/GetPnr")]
        [HttpGet]
        public int  Get()
        {
            var data = db.Flight_Reservation.Max(x => x.Pnr_no);
            return data;
        }

        //[Route("api/Booking/GetLatestPnr")]
        //[HttpGet]
        //public IEnumerable<sp_latestpnr_Result> Get()
        //{
        //    try
        //    {
        //        //var res = db.sp_latestpnr().ToList();
        //        return db.sp_latestpnr().ToList();
        //        //return db.ProjectInfoes.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[Route("api/Booking/GetPnrById/{id}")]
        //[HttpGet]
        ////this method gives employee details based on some condition(id)
        //public  Flight_Res Get(int id)
        //{
        //    try
        //    {
        //        var data = db.Flight_Reservation.Where(x => x.User_Id == id).ToList();
        //        //var data1= 
        //        //           from fr in db.Flight_Reservation
        //        //           select top 1  from 




        //        //var res = db.Flight_Reservation(pnr).ToList();
        //        if (data == null)
        //        {
        //            throw new Exception("Invalid Id");
        //        }
        //        else
        //        {
        //            return data;
        //        }


        //        //return db.ProjectInfoes.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [Route("api/Booking/InsertPassengerDetails")]
        [HttpPost]
        public bool Post([FromBody] Passenger_Details psg)
        {
            try
            {
                db.Passenger_Details.Add(psg);
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

        [Route("api/Booking/InsertPaymentDetails")]
        [HttpPost]
        public bool Post([FromBody] Payment_Details pay)
        {
            
            try
            {
                db.Payment_Details.Add(pay);
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


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //[Route("api/Booking/GetSeats")]
        //[HttpGet]
        //public string Get(int Flight_Number)
        //{
        //    //var data = db.Flight_Schedules.Where(x => x.Flight_Number==Flight_Number);
        //    //var datax=data.Select(x=>x.Seats)
        //    var seats = from fs in db.Flight_Schedules
        //                   where fs.Flight_Number == Flight_Number
        //                   select fs.Seats;
        //    return seats;
        //}
        [Route("api/Booking/GetSeats/{Flight_Number}")]
        [HttpGet]
        public string Get(int Flight_Number)
        {
            try
            {
                var data = db.sp_GetSeatsByFlightNo(Flight_Number).FirstOrDefault();
                //db.sp_GetSeatsByFlightNo.Flight_Number
                if (data == null)
                {
                    throw new Exception("Invalid Flight Number");
                }
                else
                {
                    return data;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }


        [Route("api/Booking/UpdateSeats/{Flight_Number}/{Seats}/{Pnr_no}")]
        [HttpPost]
        public bool Post(int Flight_Number,string Seats, int Pnr_no)
        {
            try
            {
                db.sp_UpdateSeats(Flight_Number,Seats);
                var data = db.Flight_Reservation.Where(x => x.Pnr_no == Pnr_no).SingleOrDefault();
                data.status = "Success";
                var res=db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





    }
}
