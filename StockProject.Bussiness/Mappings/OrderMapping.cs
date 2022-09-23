using StockProject.DataAccess.Context;
using StockProject.DataAccess.Repositories;
using StockProject.Dtos.OrderDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public class OrderMapping
    {
       

        public OrderCreateDto OrderToDtoCreate(Order order)
        {
            
            return new OrderCreateDto()
            {
                UserId = order.UserId,
                ProductId = order.ProductId,
                Piece = order.Piece,
                TotalPrice = order.TotalPrice,
            };
        }
        public Order DtoToOrderCreate(OrderCreateDto orderDto)
        {
            return new Order()
            {
                UserId = orderDto.UserId,
                ProductId = orderDto.ProductId,
                Piece = orderDto.Piece,
                TotalPrice = orderDto.TotalPrice,
            };
        }

        public OrderUpdateDto OrderToDtoUpdate(Order order)
        {
            return new OrderUpdateDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductId = order.ProductId,
                Piece = order.Piece,
                TotalPrice = order.TotalPrice,
            };
        }
        public Order DtoToOrderUpdate(OrderUpdateDto orderDto)
        {
            return new Order()
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
                ProductId = orderDto.ProductId,
                Piece = orderDto.Piece,
                TotalPrice = orderDto.TotalPrice,
            };
        }

        public OrderListDto OrderToDtoList(Order order)
        {

            return new OrderListDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductId = order.ProductId,
                Piece = order.Piece,
                TotalPrice = order.TotalPrice,

            };
        }
        public Order DtoToOrderList(OrderListDto orderDto)
        {
            return new Order()
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
                ProductId = orderDto.ProductId,
                Piece = orderDto.Piece,
                TotalPrice = orderDto.TotalPrice,
            };
        }
    }
}
