using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Entities.Entity
{
    public class UsersUserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

    }
}
