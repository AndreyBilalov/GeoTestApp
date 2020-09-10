using GeoTestApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTestApp.Domain
{
    public class CompressByGettingEveryNthCoordinates : ICompressionStrategy
    {
        private int Nth = 2;

        public void SetNth(int nTh)
        {
            if (nTh <= 0)
                throw new ArgumentException("Nth can not be less 1");

            Nth = nTh;
        }

        public void Compress(ref float[][] coordinates)
        {
            coordinates = coordinates.Where((x, i) => i % Nth == 0).ToArray();
        }
    }
}
