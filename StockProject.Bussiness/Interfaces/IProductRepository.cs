using StockProject.DataAccess.Interfaces;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
