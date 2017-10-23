using System.IO;
using Autofac;
using Middleware.Products.Data.Models;
using Middleware.Products.Images;
using Middleware.Products.Images.Models;
using MongoDB.Driver;

namespace Middleware.Products
{
    public class ProductsModule : Module
    {
        private readonly string _environment;

        public ProductsModule(string environment)
        {
            _environment = environment ?? throw new System.ArgumentNullException(nameof(environment));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Images.Writer>().As<IWriter<string>>();
            builder.RegisterType<Data.Writer>().As<IWriter<string>>();

            if (_environment == "InMemoryStore")
            {
                builder.RegisterType<Data.Db.InMemory>().As<IWriter<Brandbank>>();
            }
            else
            {
                builder.Register(ctx => new MongoClient("mongodb://192.168.1.72:27017").GetDatabase("Products")).As<IMongoDatabase>();

                builder.RegisterType<Data.Db.MongoDbStore>()
                    .As<IWriter<BrandbankWrapped>>()
                    .As<IReader<BrandbankWrapped>>();

                builder.RegisterType<Images.Db.MongoImageStore>()
                    .As<IWriter<ImageWrapped>>()
                    .As<IReader<ImageWrapped>>();                    
            }

            builder.RegisterType<ProductOptions>().As<IProductOptions>();
            builder.RegisterType<ProducerProcessor>().As<IProductProcessor>();
        }
    }
}