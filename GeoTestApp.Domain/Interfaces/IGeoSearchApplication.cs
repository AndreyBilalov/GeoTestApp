using GeoTestApp.ApplicatinLayer;
using GeoTestApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.Domain.Interfaces
{
    public interface IGeoSearchApplication
    {
        Task<IEnumerable<GeoObject>> GetCoordinatesByQueryAddress(QueryArgs queryArgs);
    }
}
