using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class DeleteMovieCommand
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommand(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task HandleAsync(Guid id)
        {
            if (!await _movieRepository.ExistsAsync(id))
            {
                throw new DomainException($"Entity id {id} does not exists");
            }

            await _movieRepository.DeleteAsync(id);
        }
    }

}
