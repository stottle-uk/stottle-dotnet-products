using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Products.Extensions;

namespace Middleware.Products
{
    public class ProducerProcessor : IProductProcessor
    {
        private readonly IProductOptions _options;
        private readonly IWriter _imageWriter;
        // private readonly IWriter _documentWriter;
        // private readonly IWriter _productDataWriter;

        public ProducerProcessor(
            IProductOptions options,
            IWriter imageWriter
            // IWriter documentWriter,
            // IWriter productDataWriter
            )
        {
            _options = options;
            _imageWriter = imageWriter;
            // _documentWriter = documentWriter;
            // _productDataWriter = productDataWriter;
        }

        public void Start()
        {
            if (!Directory.Exists(_options.Path))
            {
                throw new FileNotFoundException(_options.Path);
            }

            var directoryItems = new [] { "Documents", "Images", "product.json" };

            var t = Directory
                .GetDirectories(_options.Path)
                .GetDirectoryItems(directoryItems, (path) => throw new FileNotFoundException(path))
                .Select(folder => _imageWriter.Save(folder))
                .ToList();
        }
    }
}