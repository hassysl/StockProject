using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        //Task<T> FindAsync(object id);

        void Remove(T entity);

        Task CreateAsync(T entity);

        void Update(T entity, T unchanged);


    }
}
