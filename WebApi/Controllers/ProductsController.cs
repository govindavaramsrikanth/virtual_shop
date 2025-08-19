using Microsoft.AspNetCore.Mvc;
using WebApi.models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = [ new Product { Id = 1, Name = "Laptop", IsAvailable = true, Description = "High performance laptop" },
                                                              new Product { Id = 2, Name = "Mobile", IsAvailable = true, Description = "Latest smartphone" },
                                                              new Product { Id = 3, Name = "Tablet", IsAvailable = false, Description = "Portable tablet device" } ];

        [HttpGet]
        public IActionResult GetProducts()
        {
            // This method will return a list of products
            return Ok(products);
        }

        public IActionResult GetActiveProcucts()
        {
            // This method will return a list of active products
            var activeProducts = products.Where(p => p.IsAvailable).ToList();
            return Ok(activeProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product != null ? Ok(product) : NotFound($"Product with ID {id} not found.");
        }



        /*
        to post a new product http://localhost:5090/api/products
        Sample data for creating a product
        {
            "Name": "New Product",
            "IsAvailable": true,
            "Description": "This is a new product."
        }
        */

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Description))
            {
                return BadRequest("Invalid product data.");
            }

            product.Id = products.Max(p => p.Id) + 1; // Simple ID generation
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


        /*
        To use this endpoint, send a PUT request to http://localhost:5090/api/products/{id}
        with the following JSON body:
        {
            "Name": "Updated Product",
            "IsAvailable": true,
            "Description": "This is an updated product description."
        }
        */


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            product.Name = updatedProduct.Name;
            product.IsAvailable = updatedProduct.IsAvailable;
            product.Description = updatedProduct.Description;

            return Ok(product.Name);
        }

        /*To use this endpoint,
         send a PATCH request to http://localhost:5090/api/products/{id}
        with the following JSON body:
        {    "Name": "New Product Name"
        }
        or send a simple string in the body like "New Product Name".
        This will update only the Name property of the product with the specified ID.*/

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] String newname)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            product.Name = newname;
            // Assuming we only want to update the name for this example
            // In a real application, you might want to handle other properties as well
            // You can also add validation here if needed
            // For example, check if the new name is not null or empty
            if (string.IsNullOrEmpty(newname))
            {
                return BadRequest("Product name cannot be null or empty.");
            }
            return Ok(product);
        }


/*To use this endpoint, send a PATCH request to http://localhost:5090/api/products/deactivate/{id}
with no body. This will mark the product as unavailable (soft delete) by setting IsAvailable to false.
You can also send a simple string in the body, but it's not required for this endpoint.
This is useful for soft deleting a product without removing it from the database.   */

        [HttpPatch("deactivate/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            product.IsAvailable = false; // Soft delete by marking as unavailable
            return Ok(); // 204 No Content response
        }   


/*To use this endpoint, send a DELETE request to http://localhost:5090/api/products/{id}
This will remove the product with the specified ID from the list.
You can also send a simple string in the body, but it's not required for this endpoint.     */
[HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            products.Remove(product);
            return NoContent(); // 204 No Content response
        }       

    }
        
}