using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetMovieByIdQuery
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdQuery(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<Movie> HandleAsync(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }
    }
}
