using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Entities.Entity
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public int Piece { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
