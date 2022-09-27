using StockProject.Common;
using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IUserService
    {
        Task<IResponse<UserCreateDto>> CreateAsync(UserCreateDto dto);


        Task<IResponse<List<UserListDto>>> GetAllAsync();


        Task<IResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto dto);



        Task<IResponse> RemoveAsync(int id);


        Task<IResponse<User>> GetByIdAsync<IDto>(int id);
        Task<bool> CheckUserAsync(string username);


    }
}
