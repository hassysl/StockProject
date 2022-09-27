using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;
using StockProject.Dtos.UserDtos;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            var created = await _service.CreateAsync(userCreateDto);
            if (created == null)
            {
                return BadRequest(userCreateDto);
            }
            return Created(string.Empty, created);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {

            var updated = await _service.UpdateAsync(userUpdateDto);

            if (updated == null)
            {
                return BadRequest(userUpdateDto);
            }
            return Ok(userUpdateDto);
        }

        //[Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var userList = await _service.GetAllAsync();
            if (userList == null)
            {
                return BadRequest();
            }
            return Ok(userList);
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
