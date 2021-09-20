using CubeCollision.API.Models;
using CubeCollision.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VacationRental.Api.Tests;
using Xunit;

namespace CubeCollision.API.Tests
{
    [Collection("Integration")]
    public class PostArenaTests
    {
        private readonly HttpClient _client;

        public PostArenaTests(IntegrationFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GivenCompleteRequest_WhenPostArena_ReturnsSuccessCode()
        {
            var arenaBindingModel = new ArenaBindingModel
            {
                FirstCube = new Cube(10, 10, 10, 100, 100, 100),
                SecondCube = new Cube(10, 10, 10, 95, 95, 95)
            };
            using (var postArenaResponse = await _client.PostAsJsonAsync($"/api/CubeCollision", arenaBindingModel))
            {
                Assert.True(postArenaResponse.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task GivenInvalidRequest_WhenPostArena_ReturnsInvalidCode()
        {
            var arenaBindingModel = new ArenaBindingModel
            {
                FirstCube = new Cube(0, 0, 0, 0, 0, 0),
                SecondCube = new Cube(10, 10, 10, 95, 95, 95)
            };
            using (var postArenaResponse = await _client.PostAsJsonAsync($"/api/CubeCollision", arenaBindingModel))
            {
                Assert.True(postArenaResponse.IsSuccessStatusCode);
            }
        }
    }
}
