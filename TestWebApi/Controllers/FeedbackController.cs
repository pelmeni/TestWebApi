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
        public void Post(int id, [FromBody] string value)
        {
            FeedbackOperations.SetDriverFeedback(id, int.Parse(value));
        }
    }
}
