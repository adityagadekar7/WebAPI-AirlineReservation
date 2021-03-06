using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_AirlineReservation.Models;
using System.Web.Http.Cors;
using System.Globalization;
//Controller for -- User Dashboard--Booked,Cancelled Tickets,payment related functions

namespace WebAPI_AirlineReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Dashboard")]

    public class DashboardController : ApiController
    {

        AirlineDBEntities db = new AirlineDBEntities();

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
        
        [Route("api/Dashboard/GetPsgDetailsByPnr/{pnr}")]
        [HttpGet]
        public IEnumerable<sp_GetPsgDetailsByPnr_Result> Get(int pnr, float? ab=1)
        {
            try
            {
                var res = db.sp_GetPsgDetailsByPnr(pnr).ToList();
                if (res == null)
                {
                    throw new Exception("NO Details");
                }
                else
                {
                    return db.sp_GetPsgDetailsByPnr(pnr).ToList();
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
        public Flight_Reservation Get(int pnr,int? test=50000)
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
                    olddata.status = "Cancelled";
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

        [Route("api/Dashboard/GetFlightByFlightNumber/{Flight_Number}")]
        [HttpGet]
        public Flight_Schedules Get(int Flight_Number, long? test=121)
        {
            try
            {
                var data = db.Flight_Schedules.Where(x => x.Flight_Number == Flight_Number).SingleOrDefault();
                return data;          
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        [Route("api/Dashboard/CompareTicketTime/{Flight_Number}")]
        [HttpGet]
        public int Get(int Flight_Number, int? test1=122, int? test2=1)
        {
            try
            {
                //test = "";
                var data = db.Flight_Schedules.Where(x => x.Flight_Number == Flight_Number).FirstOrDefault();
                var FlightDate = data.Flight_Date;
                var FlightTime = data.Flight_Departing_Time;
                var mergeFlight = FlightDate + FlightTime;
                DateTime CurrentDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                DateTime CurrentDateTimeAdded3 = CurrentDateTime.AddHours(3);
                CultureInfo culture = new CultureInfo("en-US");
                DateTime FlightDateTime = Convert.ToDateTime(mergeFlight, culture);
                if (CurrentDateTimeAdded3 < FlightDateTime)
                {
                    return 1;
                }
                else
                {
                    return 0;
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Payment Part
        [Route("api/Dashboard/PaymentCheck/{UserId}/{CardNo}/{cardtype}/{Expiry_month}/{Expiry_year}")]
        [HttpGet]
        public string Get(int UserId, long Cardno, string cardtype, int Expiry_month, int Expiry_year)
        {
            string result = "";


            try
            {
                var data = db.Payment_Details.Where(x => x.User_Id == UserId && x.CardNo == Cardno && x.cardtype == cardtype && x.Expiry_Month == Expiry_month
                && x.Expiry_year == Expiry_year);
                if (data.Count() == 0)
                {
                    result = "New card added";

                }
                else
                {
                    result = "Payment Successful";

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [Route("api/Dashboard/EnterPayment/{uid}")]
        [HttpPost]
        public bool Post(int uid,[FromBody] Payment_Details pd)
        {
            try
            {
                pd.User_Id = uid;
                db.Payment_Details.Add(pd);
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


        [Route("api/Dashboard/AlterBalance/{Cardno}/{Balance}")]
        [HttpPut]
        public bool Put(long Cardno, long Balance )
        {
            try
            {
                
                var details=db.Payment_Details.Where(x=>x.CardNo==Cardno).SingleOrDefault();
                details.Balance -= Balance;
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


        [Route("api/Dashboard/UpdateCancelledSeats/{Flight_Number}/{Seats}")]
        [HttpPost]
        public bool Post(int Flight_Number, string Seats)
        {
            try
            {
                db.sp_UpdateSeats(Flight_Number, Seats);
                var data = db.Flight_Schedules.Where(x => x.Flight_Number == Flight_Number).SingleOrDefault();
                data.Seats = Seats;
                var res = db.SaveChanges();
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
