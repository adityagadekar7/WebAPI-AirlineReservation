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
    
    public partial class sp_BookedTickets_Result
    {
        public int User_Id { get; set; }
        public int pnr_no { get; set; }
        public string Airport_Name { get; set; }
        public string Location { get; set; }
        public int Zip_Code { get; set; }
        public System.DateTime Flight_date { get; set; }
        public int Flight_Number { get; set; }
        public string origin { get; set; }
        public string Destination { get; set; }
        public System.TimeSpan Flight_Departing_Time { get; set; }
        public System.TimeSpan Flight_Arrival_Time { get; set; }
        public System.DateTime Reservation_Date { get; set; }
        public System.TimeSpan Reservation_Time { get; set; }
        public int num_of_Seats { get; set; }
        public string Classtype { get; set; }
        public Nullable<int> total_price { get; set; }
        public string status { get; set; }
        public string Seats { get; set; }
    }
}
