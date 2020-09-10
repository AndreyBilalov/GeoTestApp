using GeoTestApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.Domain
{
    public abstract class GeoObject
    {
        public abstract void CompressCoordinates(ICompressionStrategy compressionStrategy);

    }

    
    
}
