using System.Collections.Generic;
using System.IO;
using Middleware.Products.Extensions;

namespace Middleware.Products
{
    internal class ProductFolder
    {
        public string ImagesFolder { get; set; }
        public string DataFile { get; set; }
        public string DocumentsFolder { get; set; }

        public ProductFolder(string path, Dictionary<string, string> items)
        {
            // ImagesFolder = Path.Combine(path, "Images").ValidatePath();
            // DataFile = Path.Combine(path, "product.json").ValidatePath();
            // DocumentsFolder = Path.Combine(path, "Documents").ValidatePath();
        }

        private string CombinePath(string path, string name)
        {
            return Path.Combine(path, name);
        }
    }
}