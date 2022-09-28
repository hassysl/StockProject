using StockProject.Bussiness.Interfaces;
using StockProject.Common;
using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class UsersUserRolesService : IUsersUserRolesService
    {
        private readonly IUsersUserRolesRepository _usersUserRolesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersUserRolesService(IUsersUserRolesRepository usersUserRolesRepository, IUserRepository userRepository, IUserService userService)
        {
            _usersUserRolesRepository = usersUserRolesRepository;
            _userRepository = userRepository;
            _userService = userService;
        }


        public async Task<IResponse<UserCreateDto>> CreateAsync(UsersUserRole entity)
        {
            var check = _userRepository.GetByFilterAsync(x => x.Id == entity.UserId);


            if (check != null)
            {
                return new Response<UserCreateDto>("Böyle bir kullanıcı zaten var", false);
            }
            await _usersUserRolesRepository.CreateAsync(entity);
            return new Response<UserCreateDto>(true);

        }
    }
}
