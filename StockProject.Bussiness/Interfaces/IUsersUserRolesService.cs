using StockProject.Common;
using StockProject.DataAccess.Interfaces;
using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IUsersUserRolesService  
    {
        Task<IResponse<UserCreateDto>> CreateAsync(UsersUserRole entity);
    }
}
