using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _service;

        public UserRolesController(IUserRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoleList = await _service.GetAllAsync();
            if (userRoleList == null)
            {
                return BadRequest();
            }
            return Ok(userRoleList);
        }


    }
}
