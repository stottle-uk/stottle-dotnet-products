using System;
using System.IO;

namespace Middleware.Products
{
    public class ProducerProcessor : IProductProcessor
    {
        private readonly IProductOptions _options;

        public ProducerProcessor(IProductOptions options)
        {
            _options = options;
        }
        public void Start()
        {
            if (!Directory.Exists(_options.Path))
            {
                throw new FileNotFoundException(_options.Path);
            }
        }
    }
}