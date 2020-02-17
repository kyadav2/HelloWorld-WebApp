using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PF.PfCoreHelloWorld.v1.Models;

namespace PF.PfCoreHelloWorld.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductController() { }

        public ProductController(List<Product> products)
        {
            this._products = products.ToList();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            if (product != null)
            {
                _products.Add(product);
            }
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody] Product product)
        {
            if (product != null)
            {
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Id = product.Id;
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
            }
        }

        [HttpDelete("{id}")]
        public void RemoveProduct(int id)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }
        }
    }
}
