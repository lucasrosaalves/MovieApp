using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetActorByIdQuery
    {
        private readonly IActorRepository _actorRepository;

        public GetActorByIdQuery(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task<Actor> HandleAsync(Guid id)
        {
            return await _actorRepository.GetByIdAsync(id);
        }
    }
}
