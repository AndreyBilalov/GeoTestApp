namespace GeoTestApp.Domain.Interfaces
{
    public interface ICompressionStrategy
    {
        void Compress(ref float[][] coordinates);
    }
    
}
