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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products); 
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            var product = await _productService.Create(request);
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult >Update(int id, ProductRequest request)
        {
            var product = await _productService.Update(id,request);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.Delete(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
