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
    
    public partial class sp_GetAllFlightDetails_Result
    {
        public int Flight_Number { get; set; }
        public string Flight_Name { get; set; }
        public System.DateTime Flight_Date { get; set; }
        public int Airport_Code { get; set; }
        public System.TimeSpan Flight_Departing_Time { get; set; }
        public System.TimeSpan Flight_Arrival_Time { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Flight_Status { get; set; }
        public int Cost_Eco { get; set; }
        public int Cost_Business { get; set; }
        public Nullable<int> Seats_Available_Eco { get; set; }
        public Nullable<int> Seats_Available_Business { get; set; }
        public string Seats { get; set; }
    }
}
