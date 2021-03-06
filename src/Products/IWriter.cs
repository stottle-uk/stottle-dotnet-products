using System.Threading.Tasks;

namespace Middleware.Products
{
    public interface IWriter<T>
    {
        Task SaveAsync(T item);
    }
}