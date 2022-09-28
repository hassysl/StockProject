using StockProject.Common;
using StockProject.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IAuthService 
    {
         Task<IResponse<string>> Login(UserLoginDto userLoginDto);

    }
}
