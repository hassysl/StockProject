using StockProject.Bussiness.Interfaces;
using StockProject.Bussiness;
using StockProject.Common;
using StockProject.DataAccess.Context;
using StockProject.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockProject.Bussiness.Token;

namespace StockProject.Bussiness.Services
{
    public class AuthService : IAuthService
    {
        private readonly StockProjectContext _context;
        private readonly IUserRepository _repo;
        private readonly IUserService _service;

        public AuthService(StockProjectContext context, IUserRepository repo, IUserService service)
        {
            _context = context;
            _repo = repo;
            _service = service;
        }

        public async Task<IResponse<string>> Login(UserLoginDto userLoginDto)
        {
            // var data = await _repo.GetByFilterAsync(x => x.Username == username);
            //if(data == null)
            //{
            //    return new Response<UserListDto>(false);
            //}
           

            var users = await _service.GetAllLoginAsync();
            var userList = users.Data;
            var status = userList.FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == userLoginDto.Password);
                
                //CheckUserAsync(username);
            if (status != null)
            {
                var x = new JwtTokenCreator();
                var token = x.GenerateToken();
                return new Response<string>(true, token);
            }
           return new Response<string>(false, null);
        }

    }
}
