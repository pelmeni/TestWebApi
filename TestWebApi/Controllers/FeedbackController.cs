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
    public class FeedbackController : ApiController
    {
//        // GET api/feedback
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }
        // GET api/feedback/5
//        [HttpGet]
//        public JsonResult<double?> GetAvgPoints(int id)
//        {
//            return 
//                Json(
//                FeedbackOperations.GetDriverAverageFeedback(id),
//                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
//
//        }
        /*
         var r = new XMLHttpRequest(); 
            r.open("POST","http://localhost:51094/api/feedback/5");
            r.onreadystatechange = function () {
            if (r.readyState != 4 || r.status != 200) return; 
            console.log(r.responseText);
            };
            r.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
            r.send("4");
         */
        // POST api/feedback/6
        public void Post(int id,[FromBody]string value)
        {
            FeedbackOperations.SetDriverFeedback(id,int.Parse(value));
        }

//        // PUT api/feedback/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/feedback/5
//        public void Delete(int id)
//        {
//        }
    }
}
