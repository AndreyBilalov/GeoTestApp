using GeoTestApp.ApplicatinLayer;
using GeoTestApp.Common;
using GeoTestApp.Domain.Interfaces;
using GeoTestApp.GeoServiceLibrary;
using GeoTestApp.WebApi.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Unity.Lifetime;

namespace GeoTestApp.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
          
            container.RegisterType<ILogger, Log4NetWrapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IGeoService, NominationGeoService>();
            container.RegisterType<IGeoSearchApplication, GeoSearchApplication>();

            config.DependencyResolver = new UnityResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ExceptionHandlingAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
