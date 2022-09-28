using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;
using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersUserRolesService _usersUserRolesservice;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IUsersUserRolesService service, IAuthService authService, IUserService userService)
        {
            _usersUserRolesservice = service;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var created = await _userService.CreateAsync(dto);
            if (created == null)
            {
                return BadRequest(created);
            }
            return Ok(created);
        }
        
        [HttpPost]
        public async Task<IActionResult>Login(UserLoginDto userLoginDto)
        {
            var response = await  _authService.Login(userLoginDto);
            return Ok(response);
        }
    }
}
