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
    
    public partial class sp_CancelledTickets_Result
    {
        public int Pnr_no { get; set; }
        public int User_Id { get; set; }
        public int Flight_Number { get; set; }
        public string Flight_Name { get; set; }
        public System.DateTime Flight_Date { get; set; }
        public string Airport_Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public System.DateTime Dateofcancellation { get; set; }
        public System.TimeSpan timeofcancellation { get; set; }
        public int Refund_Amount { get; set; }
        public string Status { get; set; }
        public System.DateTime Reservation_Date { get; set; }
        public System.TimeSpan Reservation_Time { get; set; }
        public int num_of_Seats { get; set; }
        public string Classtype { get; set; }
        public Nullable<int> total_price { get; set; }
    }
}
