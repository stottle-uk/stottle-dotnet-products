using System;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Products.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Middleware.Products.Images.Models
{
    public class ImageWrapped
    {
        public byte[] ImageData { get; set; }
        public string Filename { get; set; }        
    }
}