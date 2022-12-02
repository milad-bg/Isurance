using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IGenericRepositores
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(long id);
        
        Task<bool> InsertAsync(T entity);
        
        Task<bool> DeleteAsync(long id);
    }
}
