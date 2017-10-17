using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Extensions;

namespace Middleware.Products.Images
{
    public class Writer : IWriter<string>
    {
        private List<Stream> _data = new List<Stream>();

        public async Task SaveAsync(string folderPath)
        {
            var tasks = new DirectoryInfo(folderPath)
                .EnumerateDirectories()
                .Select(fi => fi.FullName)
                .GetSubDirectory("Images", path => throw new FileNotFoundException(path))
                .SelectMany(directory => directory.ConvertToStreams())                
                .Select(stream => {
                    _data.Add(stream);
                    return Task.CompletedTask;
                });

            await Task.WhenAll(tasks);
        }
    }
}