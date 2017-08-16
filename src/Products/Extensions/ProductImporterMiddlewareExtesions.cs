using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware.Products.Extesions
{
    public static class ProductImporterMiddlewareExtesions
    {
        public static IApplicationBuilder UseProductImporterMiddleware(
            this IApplicationBuilder builder)
        {
           return builder.UseMiddleware<ProductImporterMiddleware>();
        }
    }
}
