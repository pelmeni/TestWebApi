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

        // GET api/points/5
        public JsonResult<double?> Get(int id)
        {
            return Json(FeedbackOperations.GetDriverAverageFeedback(id));
        }

    }
}
