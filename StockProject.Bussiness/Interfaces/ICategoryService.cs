using StockProject.Common;
using StockProject.Dtos.CategoryDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface ICategoryService
    {
        Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto);


        Task<IResponse<List<CategoryListDto>>> GetAllAsync();


        Task<IResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto);



        Task<IResponse> RemoveAsync(int id);


        Task<IResponse<Category>> GetByIdAsync<IDto>(int id);
        
    }
}
