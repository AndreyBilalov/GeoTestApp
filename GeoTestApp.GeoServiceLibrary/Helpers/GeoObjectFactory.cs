using GeoTestApp.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.GeoServiceLibrary.GeoObject
{
    public class GeoObjectFactory
    {

        public static Domain.GeoObject Create(JToken geoJson)
        {

            switch (geoJson["type"]?.ToString().ToLower())
            {
                case "polygon":
                    return geoJson.ToObject<Polygon>();
                case "point":
                    return geoJson.ToObject<Point>();
                default:
                    return null;
            }

        }
      
    }

}
