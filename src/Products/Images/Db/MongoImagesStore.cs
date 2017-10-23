using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Data.Models;
using Middleware.Products.Images;
using Middleware.Products.Images.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Middleware.Products.Images.Db
{
    public class MongoImageStore : IWriter<ImageWrapped>, IReader<ImageWrapped>
    {
        private readonly IGridFSBucket _bucket;

        public MongoImageStore(IMongoDatabase database)
        {
            var db = database ?? throw new System.ArgumentNullException(nameof(database));
            var options = new GridFSBucketOptions
            {
                BucketName = "productImages"
            };
            _bucket = new GridFSBucket(db, options);
        }

        public async Task<ImageWrapped> ReadAsync(string filename)
        {
            return new ImageWrapped
            {
                ImageData = await _bucket.DownloadAsBytesByNameAsync(filename),
                Filename = filename
            };
        }

        public async Task SaveAsync(ImageWrapped item)
        {
            await _bucket
                .UploadFromBytesAsync(item.Filename, item.ImageData)
                .ConfigureAwait(false);
        }

    }
}