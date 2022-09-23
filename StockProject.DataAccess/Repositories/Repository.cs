using Microsoft.EntityFrameworkCore;
using StockProject.DataAccess.Context;
using StockProject.DataAccess.Interfaces;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity , new()
    {
        private readonly StockProjectContext _context;
        public Repository(StockProjectContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //public async Task<T> FindAsync(object id)
        //{
        //    return await _context.Set<T>().FindAsync(id);
        //}

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public List<T> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector)
        {
            var result = _context.Set<T>().AsNoTracking().ToList();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
