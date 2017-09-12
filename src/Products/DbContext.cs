using System.Collections.Generic;
using System.IO;

namespace Middleware.Products
{
    public class DbContext : IDbContext
    {
        private List<Stream> _data = new List<Stream>();
        
        public void Save(Stream stream)
        {
            _data.Add(stream);
        }
    }
}