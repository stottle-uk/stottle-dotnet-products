using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Data.Models;
using MongoDB.Driver;

namespace Middleware.Products.Data.Db
{
    public class MongoDbStore : IWriter<BrandbankWrapped>, IReader<BrandbankWrapped>
    {
        private readonly IMongoCollection<BrandbankWrapped> _collection;

        public MongoDbStore(IMongoDatabase database)
        {
            var db = database ?? throw new System.ArgumentNullException(nameof(database));

            _collection = db.GetCollection<BrandbankWrapped>("products");

            var index = Builders<BrandbankWrapped>.IndexKeys.Text(p => p.Pvid);
            _collection.Indexes.CreateOneAsync(index);
        }

        public async Task<BrandbankWrapped> ReadAsync(string pvid)
        {
            var filter = Builders<BrandbankWrapped>.Filter.Eq(p => p.Pvid, pvid);
            var result = await _collection.FindAsync(filter).ConfigureAwait(false);
            return await result.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task SaveAsync(BrandbankWrapped item)
        {
            await _collection.InsertOneAsync(item).ConfigureAwait(false);
        }

    }
}