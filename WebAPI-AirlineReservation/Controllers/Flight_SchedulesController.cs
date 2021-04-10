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
    [Route("api/Flight_Schedules")]
    public class Flight_SchedulesController : ApiController
    {

        AirLineDatabaseEntities db = new AirLineDatabaseEntities();

        [Route("api/Flight_Schedules/InsertFlight")]
        [HttpPost]
        public bool Post([FromBody] Flight_Schedules fs)
        {
            try
            {
                db.Flight_Schedules.Add(fs);
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



        [Route("api/Flight_Schedules/DeleteFlight/{id}")]
        [HttpDelete]  //delete
        public bool Delete(int id)
        {
            try
            {
                var del = db.Flight_Schedules.Where(x => x.Flight_Number == id).SingleOrDefault();
                if (del == null)
                {
                    throw new Exception("Id cannot be null");
                }
                else
                {
                    db.Flight_Schedules.Remove(del);
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



        //[Route("api/Flight_Schedules/ShowAllFlights")] //GetAllEmployees is URI name(similar to method name)
        //[HttpGet]
        ////this method gives employee details
        ////public IEnumerable<Employee> Get()
        //public IEnumerable<Flight_Schedules> Get()
        //{
        //    try
        //    {
        //        var data = from e in db.Flight_Schedules
        //                   join p in db.ProjectInfoes
        //                   on e.projid equals p.projid
        //                   select new EmpProjModel { EmpID = e.EmpID, EmpName = e.EmpName, Dept = e.Dept, Desg = e.Desg, Salary = e.Salary, projid = e.projid, password = e.password };
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}
