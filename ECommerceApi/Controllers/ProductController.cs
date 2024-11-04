
using Core.Entities;
using Infrastructure.Services;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products =  _services.GetProducts();
            if (products != null) 
            return Ok(products);
            return BadRequest("There are no Products");


        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _services.GetProductById(id);
            if (product != null)
                return Ok(product);
            return BadRequest("Invalid product id");
            
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
         var p = _services.Create(product);
            if (p=="ok")
            return Ok(product);
            return BadRequest("Invalid Creation");

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id) 
        {
            var product = _services.GetProductById(id);
            _services.Delete(id);
            if (product != null)
                return Ok($"{product.Name} is deleted successfuly");
            return BadRequest("Invalid product id");
        }

        [HttpPut]
        public IActionResult PutProduct(Product product) { 
       var isValid= _services.Update(product);
            if(isValid=="updated") return Ok(product);
            return BadRequest("Failed to update");
        
        }
    }
}
