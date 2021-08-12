using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetMoviesQuery
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQuery(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<IEnumerable<Movie>> HandleAsync(string name)
        {
            var result = await _movieRepository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(name)) { return result; }

            return result.Where(r => r.Name.Contains(name));
        }
    }
}
