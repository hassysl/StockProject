using StockProject.Common;
using StockProject.Dtos.CategoryDtos;
using StockProject.Dtos.OrderDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IOrderService
    {
        Task<IResponse<OrderCreateDto>> CreateAsync(OrderCreateDto dto);


        Task<IResponse<List<OrderListDto>>> GetAllAsync();


        Task<IResponse<OrderUpdateDto>> UpdateAsync(OrderUpdateDto dto);



        Task<IResponse> RemoveAsync(int id);


        Task<IResponse<Order>> GetByIdAsync<IDto>(int id);
    }
}
