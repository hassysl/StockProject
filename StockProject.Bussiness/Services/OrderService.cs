using FluentValidation;
using StockProject.Bussiness.Interfaces;
using StockProject.Common;
using StockProject.Dtos.OrderDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class OrderService : IOrderService
    {
        private readonly IValidator<OrderCreateDto> _createDtoValidator;
        private readonly IValidator<OrderUpdateDto> _updateDtoValidator;
        private readonly IOrderRepository _repo;

        public OrderService(IValidator<OrderCreateDto> createDtoValidator, IValidator<OrderUpdateDto> updateDtoValidator, IOrderRepository repo)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repo = repo;
        }

        public async Task<IResponse<OrderCreateDto>> CreateAsync(OrderCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                //mapleme
                var mappedEntity = new Order()
                {
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                    Piece = dto.Piece,
                    TotalPrice = dto.TotalPrice,
                };

                await _repo.CreateAsync(mappedEntity);
                return new Response<OrderCreateDto>(true, dto);
            }
            return new Response<OrderCreateDto>(false, dto);
        }

        public async Task<IResponse<List<OrderListDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var listDto = new List<OrderListDto>();
            foreach (var item in data)
            {
                listDto.Add(new OrderListDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    Piece = item.Piece,
                    TotalPrice = item.TotalPrice,

                });
            }

            return new Response<List<OrderListDto>>(true, listDto);
        }

        public async Task<IResponse<Order>> GetByIdAsync<IDto>(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
            {
                return new Response<Order>(false, data);
            }
            return new Response<Order>(true, data);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
            {
                return new Response(false);
            }
            _repo.Remove(data);
            return new Response(true);
        }

        public async Task<IResponse<OrderUpdateDto>> UpdateAsync(OrderUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _repo.GetByFilterAsync(x => x.Id == dto.Id); //.FindAsync(x);
                if (unchangedData == null)
                {
                    return new Response<OrderUpdateDto>(false, dto);
                }
                var entity = new Order()
                {
                    Id = dto.Id,
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                    Piece = dto.Piece,
                    TotalPrice = dto.TotalPrice,
                };
                _repo.Update(entity, unchangedData);
                return new Response<OrderUpdateDto>(true, dto);
            }
            return new Response<OrderUpdateDto>(false, dto);
        }
    }
}
