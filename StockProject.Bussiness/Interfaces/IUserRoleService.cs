using StockProject.Common;
using StockProject.Dtos.UserRoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IUserRoleService
    {

        Task<IResponse<List<UserRoleListDto>>> GetAllAsync();



    }
}
