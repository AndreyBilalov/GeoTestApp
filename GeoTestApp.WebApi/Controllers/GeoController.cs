using GeoTestApp.ApplicatinLayer;
using GeoTestApp.Common;
using GeoTestApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeoTestApp.WebApi.Controllers
{
    [RoutePrefix("api/geo")]
    public class GeoController : ApiController
    {
       
        private readonly IGeoSearchApplication geoSearchApplication;
        private readonly ILogger logger;

        public GeoController(IGeoSearchApplication _geoServiceApplication, ILogger _logger)
        {
            geoSearchApplication = _geoServiceApplication;
            logger = _logger;
        }

        [Route("Get")]
        public async Task<IHttpActionResult> Get(string address)
        {
            if(string.IsNullOrEmpty(address))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var coordinates = await geoSearchApplication.GetCoordinatesByQueryAddress(new QueryArgs() { Address = address });

            if (coordinates == null)
                return NotFound();


            return Json(coordinates);
        }

        

    }

    
}
