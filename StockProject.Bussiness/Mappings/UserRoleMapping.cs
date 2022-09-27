using StockProject.Dtos.UserRoleDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public class UserRoleMapping 
    {
        public UserRoleListDto UserRoleToDtoList(UserRole userRole)
        {
            return new UserRoleListDto()
            {
                Id = userRole.Id,
                Definition = userRole.Definition,
            };
        }
        public UserRole DtoToUserRoleList(UserRoleListDto userRoleDto)
        {
            return new UserRole()
            {
                Id = userRoleDto.Id,
                Definition = userRoleDto.Definition,
            };
        }
    }
}
