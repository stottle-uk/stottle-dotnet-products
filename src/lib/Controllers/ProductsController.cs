using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Middleware.Products;
using System.Threading.Tasks;

namespace Middleware.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductProcessor _processor;

        public ProductsController(IProductProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var t = "again";
            return Ok($"Hello world {t}");
        }
    }
}