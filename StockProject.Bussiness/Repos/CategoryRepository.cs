using StockProject.Bussiness.Interfaces;
using StockProject.DataAccess.Context;
using StockProject.DataAccess.Repositories;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Repos
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockProjectContext context) : base(context)
        {
        }
    }
}
