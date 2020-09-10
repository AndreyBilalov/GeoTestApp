using GeoTestApp.ApplicatinLayer;
using GeoTestApp.Common;
using GeoTestApp.GeoServiceLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeoTestApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            new Task(Test).Start();

            System.Console.ReadLine();
        }

        public static async void Test()
        {
            GeoSearchApplication application = new GeoSearchApplication(new NominationGeoService(new SimpleLogger()));

            var result = await application.GetCoordinatesByQueryAddress(new QueryArgs() { Address = "Екатеринбург", CoordinateCompression = 3 });

            File.WriteAllText("output.txt", result.ToString());

        }

       
    }
}
