using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Middleware.Products;
using Middleware.Products.Extesions;

namespace Middleware
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<ImageWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<ProductOptions>().As<IProductOptions>().SingleInstance();
            builder.RegisterType<ProducerProcessor>().As<IProductProcessor>().SingleInstance();

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsEnvironment("unittesting"))
            {
                throw new Exception();
            }

            app
                .UseProductImporterMiddleware()
                .UseMvcWithDefaultRoute();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<IWriter>().As<ImageWriter>().SingleInstance();
            builder.RegisterType<IProductOptions>().As<ProductOptions>().SingleInstance();
            builder.RegisterType<IProductProcessor>().As<ProducerProcessor>().SingleInstance();
        }
    }
}
