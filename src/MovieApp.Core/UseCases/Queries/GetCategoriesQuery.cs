using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetCategoriesQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<Category>> HandleAsync(string name)
        {
            var result = await _categoryRepository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(name)) { return result; }

            return result.Where(r => r.Name.Contains(name));
        }
    }
}
