using StockProject.Common;
using StockProject.Dtos.CategoryDtos;
using StockProject.Dtos.ProductDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IProductService
    {
        Task<IResponse<ProductCreateDto>> CreateAsync(ProductCreateDto dto);


        Task<IResponse<List<ProductListDto>>> GetAllAsync();


        Task<IResponse<ProductUpdateDto>> UpdateAsync(ProductUpdateDto dto);



        Task<IResponse> RemoveAsync(int id);


        Task<IResponse<Product>> GetByIdAsync<IDto>(int id);
    }
}
