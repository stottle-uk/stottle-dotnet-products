using System;
using System.IO;

namespace Middleware.Products
{
    public class ProductOptions : IProductOptions
    {
        public string Path 
        { 
            get => "E:\\Data2\\";
        }
    }
}