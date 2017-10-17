using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Extensions;

namespace Middleware.Products
{
    public class ProducerProcessor : IProductProcessor
    {
        private readonly IProductOptions _options;
        private readonly IEnumerable<IWriter<string>> _writers;

        public ProducerProcessor(
            IProductOptions options,
            IEnumerable<IWriter<string>> writers)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _writers = writers ?? throw new ArgumentNullException(nameof(writers));
        }

        public async Task StartAsync()
        {
            if (!Directory.Exists(_options.Path))
            {
                throw new FileNotFoundException(_options.Path);
            }

            var tasks = _writers
                .Select(writer => writer.SaveAsync(_options.Path));     

            await Task.WhenAll(tasks);
        }
    }
}