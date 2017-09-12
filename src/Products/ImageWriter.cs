using System;
using System.IO;
using System.Linq;
using Middleware.Products.Extensions;

namespace Middleware.Products
{
    public class ImageWriter : IWriter
    {
        private readonly IDbContext _dbContext;

        public ImageWriter(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(string folderPath)
        {
            var streams = folderPath
                .ConvertToStreams();

            foreach (var stream in streams)
            {
                _dbContext.Save(stream);
            }

        }
    }
}