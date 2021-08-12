using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Infra.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbContext _dbContext;

        public MovieRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task DeleteAsync(Guid id)
        {
            _dbContext.Movies.Remove(_dbContext.Movies.FirstOrDefault(p => p.Id == id));

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            return Task.FromResult(_dbContext.Movies.AsEnumerable());
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Movies.Any(p => p.Id == id));
        }
        public Task<Movie> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Movies.FirstOrDefault(p => p.Id == id));
        }

        public Task InsertAsync(Movie entity)
        {
            _dbContext.Movies.Add(entity);

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Movie entity)
        {
            await DeleteAsync(entity.Id);
            await InsertAsync(entity);
        }
    }
}
