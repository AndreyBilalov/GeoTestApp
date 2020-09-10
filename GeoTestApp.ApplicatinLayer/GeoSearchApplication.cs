using GeoTestApp.Domain;
using GeoTestApp.Domain.Interfaces;
using GeoTestApp.GeoServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.ApplicatinLayer
{
    public class GeoSearchApplication: IGeoSearchApplication
    {
        private readonly IGeoService _geoService;
        public GeoSearchApplication(IGeoService geoService)
        {
            this._geoService = geoService;
        }


        public async Task<IEnumerable<GeoObject>> GetCoordinatesByQueryAddress(QueryArgs queryArgs)
        {
            var geoObjects = await _geoService.GetGeoObjects(queryArgs.Address);

            if(queryArgs.CoordinateCompression > 1)
            {
                CompressByGettingEveryNthCoordinates strategy = new CompressByGettingEveryNthCoordinates();
                strategy.SetNth(queryArgs.CoordinateCompression);

                geoObjects.ToList().ForEach(x => { x.CompressCoordinates(strategy); });
            }

            return geoObjects;
        }

       
    }

   
}
