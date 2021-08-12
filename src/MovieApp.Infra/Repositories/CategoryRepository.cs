using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _dbContext;

        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task DeleteAsync(Guid id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(p => p.Id == id));

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return Task.FromResult(_dbContext.Categories.AsEnumerable());
        }
        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Categories.Any(p => p.Id == id));
        }
        public Task<Category> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Categories.FirstOrDefault(p => p.Id == id));
        }

        public Task InsertAsync(Category entity)
        {
            _dbContext.Categories.Add(entity);

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Category entity)
        {
            await DeleteAsync(entity.Id);
            await InsertAsync(entity);
        }
    }
}
