using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Data.Models;
using MongoDB.Bson;

namespace Middleware.Products.Data
{
    public class Writer : IWriter<string>
    {
        private readonly IWriter<BrandbankWrapped> _repo;

        public Writer(IWriter<BrandbankWrapped> repo)
        {
            _repo = repo;
        }

        public async Task SaveAsync(string directory)
        {
            var tasks = new DirectoryInfo(directory)
                .EnumerateDirectories()
                .Select(fi => fi.FullName)
                .Select(folderPath => $"{folderPath}/product.json")
                .Select(filePath => File.ReadAllText(filePath))
                .Select(productData => Brandbank.FromJson(productData))
                .Select(product => WrapProduct(product))
                .Select(data => _repo.SaveAsync(data));

            await Task.WhenAll(tasks);
        }

        private static BrandbankWrapped WrapProduct(Brandbank product)
        {
            return new BrandbankWrapped
            {
                Id = Guid.NewGuid().ToString(),
                Gtin = product.Identity.ProductCodes.ElementAt(0).Value,
                Pvid = product.Identity.ProductCodes.ElementAt(1).Value,
                Subcode = product.Identity.Subscription.Code,
                Description = product.Identity.DiagnosticDescription.Value,
                Data = product.ToBsonDocument()
            };
        }
    }
}