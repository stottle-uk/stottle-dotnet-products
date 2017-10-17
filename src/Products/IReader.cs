using System.Threading.Tasks;

namespace Middleware.Products
{
    public interface IReader<T>
    {
        Task<T> ReadAsync(string id);
    }
}