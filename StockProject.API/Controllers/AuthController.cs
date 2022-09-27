using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;
using StockProject.Dtos.UserDtos;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersUserRolesService _usersUserRolesservice;

        public AuthController(IUsersUserRolesService service)
        {
            _usersUserRolesservice = service;
        }

        public IActionResult Register(UserCreateDto dto)
        {
            _usersUserRolesservice.CreateAsync(dto);



            return Ok(dto);
        }
        
        [HttpPost]
        public IActionResult Login(string username)
        {
            
        }
    }
}
