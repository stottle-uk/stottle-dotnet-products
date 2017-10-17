using System;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Middleware.Products.Data.Models
{
    public class BrandbankWrapped
    {
        public string Id { get; set; }
        public BsonDocument Data { get; set; }
        public string Pvid { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public string Subcode { get; set; }
    }
}