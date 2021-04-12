using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AirlineReservation.Models
{
    public class PassengerDetailsModel
    {
        public int EmpID { get; set; }
        public int Pnr_no { get; set; }
        public int PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string CovidCertificate { get; set; }


    }
}