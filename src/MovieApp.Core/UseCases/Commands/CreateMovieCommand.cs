using MovieApp.Core.Common;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class CreateMovieCommand
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IActorRepository _actorRepository;

        public CreateMovieCommand(IMovieRepository movieRepository, ICategoryRepository categoryRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task<Movie> HandleAsync(CreateMovieRequest request)
        {
            request.Validate();

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            var actors = await _actorRepository.GetByIdsAsync(request.ActorIds);

            var entity = new Movie()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Actors = actors.ToList(),
                Category = category,
                Timestamp = DateTime.UtcNow
            };

            await _movieRepository.InsertAsync(entity);

            return entity;
        }

        public class CreateMovieRequest : ICommandRequest
        {
            public string Name { get; set; }
            public Guid CategoryId { get; set; }
            public List<Guid> ActorIds { get; set; } = new List<Guid>();

            public void Validate()
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    throw new DomainException($"Name can not be null or empty");
                }

                if (Guid.Empty == CategoryId)
                {
                    throw new DomainException($"CategoryId can not be null or empty");
                }

                if (ActorIds.Any())
                {
                    throw new DomainException($"ActorIds can not be null or empty");
                }
            }
        }
    }

}
