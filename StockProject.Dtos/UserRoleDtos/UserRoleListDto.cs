using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Dtos.UserRoleDtos
{
    public class UserRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
