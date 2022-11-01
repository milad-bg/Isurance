using Domain.Interfaces.IGenericRepositores;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepositores
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataBaseDbcontext _context;
        protected DbSet<T> dbSet;
        public GenericRepository(DataBaseDbcontext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            
            return true;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            var result = await dbSet.FindAsync(id);

            dbSet.Remove(result);
            
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

    }
}
