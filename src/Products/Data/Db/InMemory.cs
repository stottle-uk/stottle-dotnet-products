using System.Collections.Generic;
using System.Threading.Tasks;
using Middleware.Products;
using Middleware.Products.Data.Models;

namespace Middleware.Products.Data.Db
{
    public class InMemory : IWriter<Brandbank>
    {
        IList<Brandbank> _data = new List<Brandbank>();

        public InMemory()
        {
            
        }

        public Task SaveAsync(Brandbank data)
        {
            _data.Add(data);

            return Task.CompletedTask;
        }
    }
}