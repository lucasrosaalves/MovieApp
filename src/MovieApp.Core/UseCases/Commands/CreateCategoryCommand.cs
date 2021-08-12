using MovieApp.Core.Common;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.UseCases.Commands
{
    public class CreateCategoryCommand
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommand(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> HandleAsync(CreateCategoryRequest request)
        {
            request.Validate();

            var entity = request.ToCategory();

            await _categoryRepository.InsertAsync(entity);

            return entity;
        }

        public class CreateCategoryRequest : ICommandRequest
        {
            public string Name { get; set; }

            public Category ToCategory()
            {
                return new Category()
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
