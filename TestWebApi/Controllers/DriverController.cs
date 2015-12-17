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
            return Json(DriverOperations.GetList());
        }

        // GET api/driver/5
        public JsonResult<driver> Get(int id)
        {
            return Json(DriverOperations.Get(id));
        }
        
        // POST api/driver
        public void Post([FromBody]string value)
        {
            var item = JsonConvert.DeserializeObject<driver>(value);

            DriverOperations.Insert(item);
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


        #region not pure rest, but much more usefull

        //        var r = new XMLHttpRequest(); 
//        r.open("POST","http://localhost:51094/api/driver/5/Feedback");
//        r.onreadystatechange = function () {
//        if (r.readyState != 4 || r.status != 200) return; 
//        console.log(r.responseText);
//        };
//        r.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
//        r.send("4");
        // POST api/driver/5/feedback
        [Route("api/{controller}/{id}/Feedback")]
        public void PostFeedback(int id, [FromBody]string value)
        {
            FeedbackOperations.SetDriverFeedback(id,int.Parse(value));
        }
        // GET api/driver/5/avgpoints
        [Route("api/{controller}/{id}/AvgPoints")]
        public JsonResult<double?> GetAvgPoints(int id)
        {
            return Json(FeedbackOperations.GetDriverAverageFeedback(id));
        }
        // GET api/driver/5/autos
        [Route("api/{controller}/{id}/Autos")]
        public JsonResult<IEnumerable<auto>> GetAutos(int id)
        {
            return Json(DriverAutoOperations.GetDriverAutos(id));
        }
        // POST api/driver/5/auto
        [HttpPost]
        [Route("api/{controller}/{id}/Auto")]
        public void AddDriverAuto(int id, [FromBody]string value)
        {
            DriverAutoOperations.AddAutoToDriver(id, int.Parse(value));
        }
        // DELETE api/driver/5/auto
        [HttpDelete]
        [Route("api/{controller}/{id}/Auto")]
        public void RemoveDriverAuto(int id, [FromBody]string value)
        {
            DriverAutoOperations.RemoveAutoDriver(int.Parse(value), id);
        }
        #endregion


    }
}
