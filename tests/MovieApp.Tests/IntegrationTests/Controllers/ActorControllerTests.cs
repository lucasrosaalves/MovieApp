using MovieApp.Core.Domain.Entities;
using MovieApp.Tests.IntegrationTests.Server;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieApp.Tests.IntegrationTests.Controllers
{
    public class ActorControllerTests
    {
        [Fact]
        public async Task Get_ShouldReturnAllData()
        {

            using var httpClient = IntegrationServer.CreateHttpClient();
            using var response = await httpClient.GetAsync("api/actors");
            Assert.True(response.IsSuccessStatusCode);
            Assert.True((int)response.StatusCode == 200);
            Assert.NotEmpty(IntegrationServer.DeserializeObject<List<Actor>>(await response.Content.ReadAsStringAsync()));
        }

        [Fact]
        public async Task Get_ShouldReturnNoContentIfActorDoesNotExists()
        {

            using var httpClient = IntegrationServer.CreateHttpClient();
            using var response = await httpClient.GetAsync("api/actors?name=LRA");
            Assert.True(response.IsSuccessStatusCode);
            Assert.True((int)response.StatusCode == 200);
            Assert.Empty(IntegrationServer.DeserializeObject<List<Actor>>(await response.Content.ReadAsStringAsync()));
        }
    }
}
