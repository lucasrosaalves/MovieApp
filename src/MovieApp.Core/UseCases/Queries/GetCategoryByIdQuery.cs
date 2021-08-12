using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Queries
{
    public class GetCategoryByIdQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> HandleAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
    }
}
