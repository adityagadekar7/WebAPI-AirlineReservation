﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AirLineDatabaseEntities : DbContext
    {
        public AirLineDatabaseEntities()
            : base("name=AirLineDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<City_Information> City_Information { get; set; }
        public DbSet<Flight_Reservation> Flight_Reservation { get; set; }
        public DbSet<Flight_Schedules> Flight_Schedules { get; set; }
        public DbSet<Passenger_Details> Passenger_Details { get; set; }
        public DbSet<Payment_Details> Payment_Details { get; set; }
        public DbSet<User_Registration> User_Registration { get; set; }
    
        public virtual ObjectResult<sp_BookedTickets_Result> sp_BookedTickets(Nullable<int> uid)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BookedTickets_Result>("sp_BookedTickets", uidParameter);
        }
    
        public virtual ObjectResult<sp_CancelledTickets_Result> sp_CancelledTickets(Nullable<int> uid)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CancelledTickets_Result>("sp_CancelledTickets", uidParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_pnrlatest()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_pnrlatest");
        }
    
        public virtual ObjectResult<string> sp_GetSeatsByFlightNo(Nullable<int> flight_Number)
        {
            var flight_NumberParameter = flight_Number.HasValue ?
                new ObjectParameter("Flight_Number", flight_Number) :
                new ObjectParameter("Flight_Number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_GetSeatsByFlightNo", flight_NumberParameter);
        }
    
        public virtual int sp_UpdateSeats(Nullable<int> flight_Number, string seats)
        {
            var flight_NumberParameter = flight_Number.HasValue ?
                new ObjectParameter("Flight_Number", flight_Number) :
                new ObjectParameter("Flight_Number", typeof(int));
    
            var seatsParameter = seats != null ?
                new ObjectParameter("Seats", seats) :
                new ObjectParameter("Seats", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateSeats", flight_NumberParameter, seatsParameter);
        }
    }
}
