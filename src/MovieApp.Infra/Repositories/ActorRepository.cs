using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Infra.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DbContext _dbContext;

        public ActorRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task DeleteAsync(Guid id)
        {
            _dbContext.Actors.Remove(_dbContext.Actors.FirstOrDefault(p => p.Id == id));

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Actors.Any(p => p.Id == id));
        }

        public Task<IEnumerable<Actor>> GetAllAsync()
        {
            return Task.FromResult(_dbContext.Actors.AsEnumerable());
        }

        public Task<Actor> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Actors.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Actor>> GetByIdsAsync(List<Guid> ids)
        {
            return Task.FromResult(_dbContext.Actors.Where(p => ids.Exists(i => i == p.Id)));
        }

        public Task InsertAsync(Actor entity)
        {
            _dbContext.Actors.Add(entity);

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Actor entity)
        {
            await DeleteAsync(entity.Id);
            await InsertAsync(entity);
        }
    }
}
