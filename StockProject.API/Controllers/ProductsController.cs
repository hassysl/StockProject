using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;
using StockProject.Dtos.ProductDtos;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var created = await _service.CreateAsync(productCreateDto);
            if (created == null)
            {
                return BadRequest(productCreateDto);
            }
            return Created(string.Empty, created);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {

            var updated = await _service.UpdateAsync(productUpdateDto);

            if (updated == null)
            {
                return BadRequest(productUpdateDto);
            }
            return Ok(productUpdateDto);
        }

        //[Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _service.GetAllAsync();
            if (productList == null)
            {
                return BadRequest();
            }
            return Ok(productList);
        }


        //[Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }
    }
}
