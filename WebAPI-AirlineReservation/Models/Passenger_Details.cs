//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_AirlineReservation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passenger_Details
    {
        public int Passenger_id { get; set; }
        public int Pnr_no { get; set; }
        public int PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public string Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string CovidCertificate { get; set; }
    
        public virtual Flight_Reservation Flight_Reservation { get; set; }
    }
}
