using System.IO;

namespace Middleware.Products
{
    public interface IDbContext
    {
        void Save(Stream stream);
    }
}