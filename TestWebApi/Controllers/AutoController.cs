using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        // GET api/auto
        public JsonResult<IEnumerable<auto>> Get()
        {
            return Json(AutoOperations.GetList(),
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        }
        /*
         
         */
        // GET api/auto/5
        public JsonResult<auto> Get(int id)
        {
            return Json(AutoOperations.Get(id),
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
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
        public void Put(int id, [FromBody]string value)
        {
            var item = JsonConvert.DeserializeObject<auto>(value);
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
    }
}
