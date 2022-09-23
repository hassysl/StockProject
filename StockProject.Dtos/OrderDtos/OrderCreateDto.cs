using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Dtos.OrderDtos
{
    public class OrderCreateDto : IDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
