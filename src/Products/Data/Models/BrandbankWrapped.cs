using MongoDB.Bson;

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