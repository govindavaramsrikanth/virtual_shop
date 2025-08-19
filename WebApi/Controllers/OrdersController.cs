namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.models;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        static readonly List<Order> orders = new List<Order>
        {
                new Order { Id = 1, ProductName = "Laptop", CustomerName = "John Doe", TotalAmount = 1200.00m },
                new Order { Id = 2, ProductName = "Mobile", CustomerName = "Jane Smith", TotalAmount = 800.00m },
                new Order { Id = 3, ProductName = "Tablet", CustomerName = "Alice Johnson", TotalAmount = 600.00m },
                new Order { Id = 4, ProductName = "Smartwatch", CustomerName = "Bob Brown", TotalAmount = 300.00m }

        };
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


        /*        To post a new order, use the following endpoint:
        http://localhost:5090/api/orders
        Sample data for creating an order:
        {         "ProductName": "New Product",
            "CustomerName": "John Doe",                                                                             
            "TotalAmount": 150.00
        }
        */
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null || string.IsNullOrEmpty(order.ProductName) || string.IsNullOrEmpty(order.CustomerName))
            {
                return BadRequest("Invalid order data.");
            }

            // Assign a new Id
            order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
          
            orders.Add(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

    }
}