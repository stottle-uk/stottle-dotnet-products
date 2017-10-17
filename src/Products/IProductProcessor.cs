using System.Threading.Tasks;

namespace Middleware.Products
{
    public interface IProductProcessor
    {
        Task StartAsync();
    }
}