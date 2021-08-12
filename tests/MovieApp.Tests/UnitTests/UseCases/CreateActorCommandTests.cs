using Moq;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.Exceptions;
using MovieApp.Core.UseCases.Commands;
using System.Threading.Tasks;
using Xunit;

namespace MovieApp.Tests.UnitTests.UseCases
{
    public class CreateActorCommandTests
    {
        private readonly IActorRepository _basicActorRepository;
        public CreateActorCommandTests()
        {
            _basicActorRepository = new Mock<IActorRepository>().Object;
        }

        [Fact]
        public async Task HandleAsync_ShouldThrowDomainExceptionIfRequestInvalid()
        {

            var service = new CreateActorCommand(_basicActorRepository);

            await Assert.ThrowsAsync<DomainException>(async () => await service.HandleAsync(new CreateActorCommand.CreateActorRequest()
            {
                Name = null
            }));
        }

        [Fact]
        public async Task HandleAsync_ShouldCreateActorIfRequestValid()
        {

            var service = new CreateActorCommand(_basicActorRepository);

            var result = await service.HandleAsync(new CreateActorCommand.CreateActorRequest()
            {
                Name = "Actor 1"
            });

            Assert.NotNull(result);
            Assert.Equal("Actor 1", result.Name);
        }
    }
}
