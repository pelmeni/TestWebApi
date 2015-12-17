using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestWebApi.Business;
using TestWebApi.Data;

namespace TestWebApi.Controllers
{
    public class DriverAutosController : ApiController
    {
        // GET api/driverautos/5
        public JsonResult<IEnumerable<auto>> Get(int id)
        {
            return Json(DriverAutoOperations.GetDriverAutos(id));
        }

        // POST api/driverautos
        public void Post(int id, [FromBody]string value)
        {
            DriverAutoOperations.AddAutoToDriver(id, int.Parse(value));   
        }

        // DELETE api/driverautos/5
        public void Delete(int id, [FromBody]string value)
        {
            DriverAutoOperations.RemoveAutoDriver(int.Parse(value),id);
        }
    }
}
