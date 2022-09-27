using StockProject.Bussiness.Interfaces;
using StockProject.Common;
using StockProject.Dtos.UserRoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repo;

        public UserRoleService(IUserRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResponse<List<UserRoleListDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var listDto = new List<UserRoleListDto>();
            foreach (var item in data)
            {
                listDto.Add(new UserRoleListDto()
                {
                    Id = item.Id,
                    Definition = item.Definition,

                });
            }

            return new Response<List<UserRoleListDto>>(true, listDto);
        }
    }
}

