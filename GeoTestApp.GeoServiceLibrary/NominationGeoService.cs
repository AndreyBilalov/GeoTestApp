using GeoTestApp.Common;
using GeoTestApp.Domain;
using GeoTestApp.Domain.Interfaces;
using GeoTestApp.GeoServiceLibrary.GeoObject;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.GeoServiceLibrary
{
    public class NominationGeoService:WebService, IGeoService
    {
        private string outputFormat = "&polygon_geojson=1&format=jsonv2";
        private string base_url = "https://nominatim.openstreetmap.org/search.php?q=";

        public NominationGeoService(ILogger _logger):base(_logger)
        {

        }

        public async Task<IEnumerable<Domain.GeoObject>> GetGeoObjects(string searchQuery)
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(base_url + searchQuery + outputFormat))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var stringResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    var jsonObject = JArray.Parse(stringResult);

                    return GetGeoObjects(jsonObject);

                }
                else
                {
                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
            }

        }

        private IEnumerable<Domain.GeoObject> GetGeoObjects(JToken jObject) 
        {
            try
            {
                var geoJsons = jObject.Select(x => x["geojson"]).ToList();

                var geoObjects = geoJsons.Select(x => GeoObjectFactory.Create(x)).ToList();

                geoObjects.RemoveAll(x => x == null);

                return geoObjects; 
            }
            catch (Exception ex)
            {
                logger.LogMessage(ex.ToString());
                throw;
            }
           
        }

       
        

    }

    

 

}
