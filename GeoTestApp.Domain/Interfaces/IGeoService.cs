using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.Domain.Interfaces
{
    public interface IGeoService
    {
        Task<IEnumerable<GeoObject>> GetGeoObjects(string queryAddress);
    }
}
