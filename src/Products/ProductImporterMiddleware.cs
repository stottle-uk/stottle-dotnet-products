using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware.Products
{
    public class ProductImporterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IProductProcessor _productProcessor;

        public ProductImporterMiddleware(RequestDelegate next, IProductProcessor productprocessor)
        {
            _next = next;
            _productProcessor = productprocessor;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Equals("/api/products", StringComparison.CurrentCultureIgnoreCase))
                _productProcessor.Start();

            await _next(context);
        }

    }
}
