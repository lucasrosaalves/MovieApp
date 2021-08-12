using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetActorsQuery
    {
        private readonly IActorRepository _actorRepository;

        public GetActorsQuery(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task<IEnumerable<Actor>> HandleAsync(string name)
        {
            var result =  await _actorRepository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(name)) { return result; }

            return result.Where(r => r.Name.Contains(name));
        }
    }
}
