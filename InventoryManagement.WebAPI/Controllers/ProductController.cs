using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.WebAPI.Services;
using System.Reflection.Metadata.Ecma335;
using InventoryManagement.WebAPI.Models;


namespace InventoryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAllProduct();
            return Ok(products); 
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductRequest request)
        {
            var product = _productService.Create(request);
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, ProductRequest request)
        {
            var product = _productService.Update(id,request);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var success = _productService.Delete(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
