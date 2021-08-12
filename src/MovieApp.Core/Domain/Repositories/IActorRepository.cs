using MovieApp.Core.Common;
using MovieApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Domain.Repositories
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<IEnumerable<Actor>> GetByIdsAsync(List<Guid> ids);
    }
}
