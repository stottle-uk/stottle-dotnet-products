using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Middleware.Products;
using Xunit;

namespace Middleware.lib.Tests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://*:" + 5000.ToString())
                .ConfigureServices(s => s.AddSingleton<IProductOptions, ProductOptions>())
                .ConfigureServices(s => s.AddSingleton<IProductProcessor, ProducerProcessor>());

            var server = new TestServer(builder);

            var client = server.CreateClient();

            var result = client.GetAsync("/").Result;

            Startup.ApplicationCenter.

            Assert.Equal(result.Content.ReadAsStringAsync().Result, "Add(2, 2)");
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}