using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Autofac;
using MongoDB.Driver;
using System.Linq;
using Middleware.Products.Data.Models;
using Middleware.Products;

namespace Middleware.lib.Tests
{
    public class Class1
    {
        private IReader<BrandbankWrapped> _dbStore => Startup.ApplicationContainer.Resolve<IReader<BrandbankWrapped>>();

        [Fact]
        public void PassingTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("unittesting")
                .UseStartup<Startup>()
                .UseUrls("http://*:" + 5000.ToString());

            var db = new MongoClient("mongodb://192.168.1.72:27017").GetDatabase("Products");
            db.DropCollection("products");

            var server = new TestServer(builder);

            var client = server.CreateClient();

            var result = client.GetAsync("api/products").Result;

            Assert.Equal("Hello world again", result.Content.ReadAsStringAsync().Result);

            var t = _dbStore.ReadAsync("3988596").Result;
            Assert.Equal("3988596", t.Pvid);

        }
    }
}