using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness;
using StockProject.Bussiness.Interfaces;
using StockProject.Bussiness.Mappings;
using StockProject.DataAccess.Context;
using StockProject.Dtos.CategoryDtos;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var created = await _service.CreateAsync(categoryCreateDto);
            if (created == null)
            {
                return BadRequest(categoryCreateDto);
            }
            return Created(string.Empty, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {

           var updated = await _service.UpdateAsync(categoryUpdateDto);

            if (updated == null)
            {
                return BadRequest(categoryUpdateDto);
            }
            return Ok(categoryUpdateDto);
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _service.GetAllAsync();
            if (categoryList == null)
            {
                return BadRequest();
            }
            return Ok(categoryList);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            await _service.GetByIdAsync<CategoryListDto>(id);
            return NoContent();
        }



    }
}
