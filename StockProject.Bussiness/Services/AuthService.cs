using StockProject.Bussiness.Interfaces;
using StockProject.Bussiness.Token;
using StockProject.Common;
using StockProject.DataAccess.Context;
using StockProject.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class AuthService
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

        public async Task<IResponse<UserListDto>> Login(string username)
        {
            var data = await _repo.GetByFilterAsync(x => x.Username == username);
            var dto = new UserListDto()
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname,
                Username = data.Username,
            };

            var status = await _service.CheckUserAsync(username);
            if (status == true)
            {
                var x = new JwtTokenCreator().GenerateToken();
                return new Response<UserListDto>(true, dto);
            }
           return new Response<UserListDto>(false, dto);
        }

    }
}
