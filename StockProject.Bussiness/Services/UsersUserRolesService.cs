using StockProject.Bussiness.Interfaces;
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
        private readonly IUsersUserRolesRepository _repo;

        public UsersUserRolesService(IUsersUserRolesRepository usersUserRolesRepository)
        {
            _repo = usersUserRolesRepository;
        }

        public async Task CreateAsync(UsersUserRole entity)
        {
            await _repo.CreateAsync(entity);
        }

        
    }
}
