﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using TestWebApi.Business;
using TestWebApi.Data;

namespace TestWebApi.Controllers
{
    public class AutoDriverController : ApiController
    {
        // GET api/autodriver/5
        [HttpGet]
        public JsonResult<IEnumerable<driver>> GetDrivers(int id)
        {
            return Json(DriverAutoOperations.GetAutoDrivers(id));
        }

        // POST api/autodriver
        public void Post(int id, [FromBody]string value)
        {
            DriverAutoOperations.AddAutoToDriver(int.Parse(value),id);   
        }

        // DELETE api/autodriver/5
        public void Delete(int id, [FromBody]string value)
        {
            DriverAutoOperations.RemoveAutoDriver(id, int.Parse(value));   
        }
    }
}
