using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            // This method will return a list of products
            return Ok(new[] { "Laptop", "Mobile", "Tablet" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            return Ok($"Product{id}");
        }   

    }
        
}