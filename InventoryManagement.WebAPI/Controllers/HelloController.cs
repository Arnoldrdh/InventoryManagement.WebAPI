using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using InventoryManagement.WebAPI.Models;

namespace InventoryManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Hello, id = {id}"); 
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductRequest request)
        {
            return Ok("Create Hello");
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id)
        {
            return Ok($"Update id = {id}"); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete (int id)
        {
            return Ok($"Delte id = {id}");
        }

        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            return Ok($"Keyword = {keyword}");
        }
    }
}
