using GeoTestApp.Common;
using log4net;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace GeoTestApp.WebApi.Helpers
{
    public class Log4NetWrapper : ExceptionLogger, ILogger
    {
        private readonly ILog log; 

        public Log4NetWrapper()
        {
            this.log = LogManager.GetLogger("GetTestApp.WebApi");
        }

        public void LogMessage(string msg)
        {
            log.Info(msg);
        }


    }

    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            var logger = new Log4NetWrapper();

            logger.LogMessage("A error occured" + context.Exception?.ToString());
        }
    }
}