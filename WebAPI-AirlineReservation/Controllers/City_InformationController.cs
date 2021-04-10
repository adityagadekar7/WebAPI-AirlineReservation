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
    [Route("api/City_Information")]
    public class City_InformationController : ApiController
    {

        AirLineDatabaseEntities db = new AirLineDatabaseEntities();

        [Route("api/City_Information/GetCity")]
        [HttpGet]
        public IEnumerable<City_Information> Get()
        {
            try
            {
                return db.City_Information.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
