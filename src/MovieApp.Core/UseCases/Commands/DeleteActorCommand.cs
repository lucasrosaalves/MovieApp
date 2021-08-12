using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class DeleteActorCommand
    {
        private readonly IActorRepository _actorRepository;

        public DeleteActorCommand(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task HandleAsync(Guid id)
        {
            if (!await _actorRepository.ExistsAsync(id))
            {
                throw new DomainException($"Entity id {id} does not exists");
            }

            await _actorRepository.DeleteAsync(id);
        }
    }
}
