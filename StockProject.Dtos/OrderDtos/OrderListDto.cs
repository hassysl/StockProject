using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Dtos.OrderDtos
{
    public class OrderListDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; } //Bu order hangi user'dan? username'i ne
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
