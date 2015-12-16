using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace TestWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithId",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
                );
//
//            config.Routes.MapHttpRoute(
//                name: "DefaultApiWithActionId",
//                routeTemplate: "api/{controller}/{action}/{id}"
//                //defaults: new { id = RouteParameter.Optional }
//            );

//            config.Routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
//            config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}/{id}");
//
//            config.Routes.MapHttpRoute("DefaultApiGet", "Api/{controller}", new { action = "Get" }, new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) });
//            config.Routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Post) });

        }
    }
}
