using GeoTestApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.Console
{
    public class SimpleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
