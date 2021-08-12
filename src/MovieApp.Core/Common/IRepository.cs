using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task InsertAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
