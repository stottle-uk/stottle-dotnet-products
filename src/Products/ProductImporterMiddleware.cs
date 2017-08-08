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
            await context.Response.WriteAsync("Greetings from MapWhen\n");
            _productProcessor.Start();
            await _next(context);
        }

    }

    public static class ProductImporterMiddlewareExtesions
    {
        public static IApplicationBuilder UseProductImporterMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProductImporterMiddleware>();

            // return builder.Map("/stuff", (appBulder) =>
            // {
            //     appBulder.Use(async (context, next) =>
            //     {
            //         await context.Response.WriteAsync("Hello from stuff 1!\n");
            //         await next.Invoke();
            //         await context.Response.WriteAsync("Hello from stuff again!\n");
            //     })
            //     .Run(async (context) =>
            //     {
            //         await context.Response.WriteAsync("Greetings from stuff\n");
            //     });
            // });
        }
    }
}
