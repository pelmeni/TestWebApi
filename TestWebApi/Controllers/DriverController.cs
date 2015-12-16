using System;
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
    public class DriverController : ApiController
    {

        // GET api/driver
        
        public JsonResult<IEnumerable<driver>> Get()
        {
            return Json(DriverOperations.GetList(),
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        // GET api/driver/5
        
        
        public JsonResult<driver> Get(int id)
        {
            return Json(DriverOperations.Get(id),
                          new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        // POST api/driver
        public void Post([FromBody]string value)
        {
            var item = JsonConvert.DeserializeObject<driver>(value);

            DriverOperations.Insert(item);
        }

//        var r = new XMLHttpRequest(); 
//        r.open("POST","http://localhost:51094/api/driver/Feedback/5");
//        r.onreadystatechange = function () {
//        if (r.readyState != 4 || r.status != 200) return; 
//        console.log(r.responseText);
//        };
//        r.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
//        r.send("4");
        public void Feedback(int id, [FromBody]string value)
        {
            FeedbackOperations.SetDriverFeedback(id,int.Parse(value));
        }

        // PUT api/driver/5
        public void Put(int id, [FromBody]string value)
        {
            var item = JsonConvert.DeserializeObject<driver>(value);
            item.driver_id = id;

            DriverOperations.Update(item);
        }

        // DELETE api/driver/5
        public void Delete(int id)
        {
            DriverOperations.Delete(id);
        }
    }
}
