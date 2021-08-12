using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class DeleteCategoryCommand
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommand(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task HandleAsync(Guid id)
        {
            if (!await _categoryRepository.ExistsAsync(id))
            {
                throw new DomainException($"Entity id {id} does not exists");
            }

            await _categoryRepository.DeleteAsync(id);
        }
    }

}
