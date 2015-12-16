using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using TestWebApi.Business;

namespace TestWebApi.Controllers
{
    public class AvgPointsController : ApiController
    {
//        // GET api/points
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

        // GET api/points/5
        public JsonResult<double?> Get(int id)
        {
            return Json(FeedbackOperations.GetDriverAverageFeedback(id),new JsonSerializerSettings());
        }

//        // POST api/points
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/points/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }
//
//        // DELETE api/points/5
//        public void Delete(int id)
//        {
//        }
    }
}
