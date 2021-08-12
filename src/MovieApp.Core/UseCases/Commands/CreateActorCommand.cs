using MovieApp.Core.Common;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class CreateActorCommand
    {
        private readonly IActorRepository _actorRepository;

        public CreateActorCommand(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task<Actor> HandleAsync(CreateActorRequest request)
        {
            request.Validate();

            var entity = request.ToActor();

            await _actorRepository.InsertAsync(entity);

            return entity;
        }

        public class CreateActorRequest : ICommandRequest
        {
            public string Name { get; set; }

            public Actor ToActor()
            {
                return new Actor()
                {
                    Id = Guid.NewGuid(),
                    Name = Name
                };
            }

            public void Validate()
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    throw new DomainException($"Name can not be null or empty");
                }
            }
        }
    }

}
