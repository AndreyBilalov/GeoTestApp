using GeoTestApp.Domain.Interfaces;
using System.Collections.Generic;

namespace GeoTestApp.Domain
{
    public class Point : GeoObject
    {
        public string Type { get; set; }
        public float[] Coordinates { get; set; }

        public override void CompressCoordinates(ICompressionStrategy compressionStrategy)
        {

        }
    }

}
