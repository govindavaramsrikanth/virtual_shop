namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            // This method will return a list of orders
            return Ok(new[] { "Order1", "Order2", "Order3" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Order{id}");
        }
    }

    
}