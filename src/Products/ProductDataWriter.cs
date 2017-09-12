using System.Collections.Generic;

namespace Middleware.Products
{
    public class ProductDataWriter : IWriter
    {
        private List<string> _data = new List<string>();

        public void Save(string folderPath)
        {
            _data.Add(folderPath);
        }
    }
}