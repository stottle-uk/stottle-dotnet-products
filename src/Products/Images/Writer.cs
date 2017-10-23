using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Extensions;
using Middleware.Products.Images.Models;

namespace Middleware.Products.Images
{
    public class Writer : IWriter<string>
    {
        private readonly IWriter<ImageWrapped> _repo;

        public Writer(IWriter<ImageWrapped> repo)
        {
            _repo = repo;
        }

        public async Task SaveAsync(string folderPath)
        {
            var tasks = new DirectoryInfo(folderPath)
                .EnumerateDirectories()
                .Select(fi => fi.FullName)
                .GetSubDirectory("Images", path => throw new FileNotFoundException(path))
                .SelectMany(directory => Directory.GetFiles(directory))
                .Select(file => new ImageWrapped
                {
                    ImageData = File.ReadAllBytes(file),
                    Filename = Path.GetFileNameWithoutExtension(file),
                })
                .Select(image => _repo.SaveAsync(image));

            await Task.WhenAll(tasks);
        }
    }
}