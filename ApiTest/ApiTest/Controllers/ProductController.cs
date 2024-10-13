using ApiTest.Entities;
using ApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts() => Ok(_productService.GetAllProducts());

        [HttpGet("{id}")]
        public ActionResult<Product?> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
