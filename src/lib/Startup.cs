using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Middleware.Products;

namespace Middleware.lib
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductOptions, ProductOptions>();
            services.AddSingleton<IProductProcessor, ProducerProcessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            var log = loggerFactory.CreateLogger("");

            log.LogDebug(new EventId(), new Exception(), $"{File.Exists("C:\\temp\\MyWildPacks_Email_636365273012828222.txt")}");

            //var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from conponent 1!\n");
                await next.Invoke();
                await context.Response.WriteAsync("Hello from conponent 1 again!\n");
            });

            app.UseProductImporterMiddleware();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!\n");
            });

        }


    }
}
