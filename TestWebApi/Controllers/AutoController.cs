using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using TestWebApi.Business;
using TestWebApi.Data;

namespace TestWebApi.Controllers
{
    
    public class AutoController : ApiController
    {
        
//        public ICollection<auto> Get()
//        {
//            return AutoOperations.GetList().ToList();
//        }
        // GET api/auto
        public JsonResult<IEnumerable<auto>> Get()
        {
            return Json(AutoOperations.GetList());
        }
        
        // GET api/auto/5
        public JsonResult<auto> Get(int id)
        {
            return Json(AutoOperations.Get(id));
        }
        /*
            var r = new XMLHttpRequest(); 
            r.open("POST","http://localhost:51094/api/auto");
            r.onreadystatechange = function () {
            if (r.readyState != 4 || r.status != 200) return; 
            console.log(r.responseText);
            };
            r.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
            r.send("\"{'auto':'0','mark':'Mercedes','model':'Clk','no':'c666aa66rus','color':'красный'\}\"");
         */
        // POST api/auto
        public void Post([FromBody] string value)
        {
            var item = JsonConvert.DeserializeObject<auto>(value);

            AutoOperations.Insert(item);
        }
        /*
            var r = new XMLHttpRequest(); 
            r.open("PUT","http://localhost:51094/api/auto/4");
            r.onreadystatechange = function () {
            if (r.readyState != 4 || r.status != 200) return; 
            console.log(r.responseText);
            };
            r.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
            r.send("\"{'auto':'0','mark':'Mercedes','model':'Clk','no':'c666aa66ua','color':'красный'\}\"");
         */
        // PUT api/auto/5
        public void Put(int id, auto item)
        {
            //var item = JsonConvert.DeserializeObject<auto>(value);
            item.auto_id = id;

            AutoOperations.Update(item);
        }
        /*
            var r = new XMLHttpRequest(); 
            r.open("DELETE","http://localhost:51094/api/auto/4",true);
            r.onreadystatechange = function () {
            if (r.readyState != 4 || r.status != 200) return; 
            console.log(r.responseText);
            };
         * 
            r.send();
         */
        // DELETE api/auto/5
        public void Delete(int id)
        {
            AutoOperations.Delete(id);
        }

                #region not pure rest, but much more usefull

        // GET api/auto/5/drivers
        [Route("api/{controller}/{id}/drivers")]
        public JsonResult<IEnumerable<driver>> GetDrivers(int id)
        {
            return Json(DriverAutoOperations.GetAutoDrivers(id));
        }


        // POST api/auto/5/driver
        [Route("api/{controller}/{id}/driver")]
        public void PostAddDriver(int id, [FromBody]string value)
        {
            DriverAutoOperations.AddAutoToDriver(int.Parse(value), id);
        }

        // DELETE api/auto/5/driver
        [HttpPut]
        [Route("api/{controller}/{id}/driver")]
        public void Delete(int id, [FromBody]string value)
        {
            DriverAutoOperations.RemoveAutoDriver(id, int.Parse(value));
        }

        #endregion
    }
}
