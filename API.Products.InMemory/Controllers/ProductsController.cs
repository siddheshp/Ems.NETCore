using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Products.InMemory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Products.InMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static Category category = new Category
        {
            Id = 1,
            Name = "Electronics"
        };

        static List<Product> products = new List<Product>
        {
            new Product{Id=1, Name="laptop",Price=50000,
                DateAdded = new DateTime(2019,1,1), Category= category},
            new Product{Id=2, Name="computer",Price=20000,
                DateAdded = new DateTime(2019,11,12), Category= category}
        };
        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            if (!products.Any())
            {
                return NoContent();
            }
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.Id)
            {
                return BadRequest("Product ids do not match");
            }
            var existingProduct = products.Find(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            //update
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.DateAdded = product.DateAdded;
            existingProduct.Category = product.Category;
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = products.Find(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            products.Remove(existingProduct);
            return Ok();
        }
    }
}
