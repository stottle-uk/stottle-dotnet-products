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
                .UseEnvironment("unittesting")
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://*:" + 5000.ToString());

            var server = new TestServer(builder);

            var client = server.CreateClient();

            var result = client.GetAsync("api/products").Result;

            Assert.Equal("Hello world again", result.Content.ReadAsStringAsync().Result);
        }
    }
}