//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using WebAPI_AirlineReservation.Models;
//using System.Web.Http.Cors;

//namespace WebAPI_AirlineReservation.Controllers
//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    [Route("api/Flight_Reservation")]
//    public class Flight_ReservationController : ApiController
//    {
//        AirlineDBEntities db = new AirlineDBEntities();
//        //[Route("api/Flight_Reservation/GetFlight/{id}")]
//        //[HttpGet]
//        //public Flight_Reservation Get(int id)

//        //{
//        //    try
//        //    {
//        //        var data = db.Flight_Reservation.Where(x => x.Flight_Number == id);
//        //        if (data == null)
//        //            throw new Exception("Invalid Flight Number");
//        //        else
//        //            return (Flight_Reservation)data;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//        [Route("api/Flight_Reservation/GetFlights")]
//        [HttpGet]
//        public IEnumerable<Flight_Schedules> Get()
//        {
//            try
//            {
//                return db.Flight_Schedules;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


        


//    }
//}
