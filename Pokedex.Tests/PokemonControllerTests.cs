using Microsoft.AspNetCore.Mvc.Testing;
using Pokedex.Api;
using Pokedex.Core.Models;
using Pokedex.Tests.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string PokemonName = "mewtwo";
        private const string PokemonDescription = "Created by a scientist after years of horrific gene splicing and dna engineering experiments,  it was.";

        protected const string BaseUrl = "/Pokemon";

        private readonly HttpClient _httpClient;
        public PokemonServiceTests(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetPokemon_ByName_Success()
        {
            // Arrange
            var request = new { Url = $"{BaseUrl}/{PokemonName}" };

            // Act
            var response = await _httpClient.GetAsync(request.Url);
            var content = await response.Content.ReadAsStringAsync();
            var result = ContentHelper.GetRequestResult<PokemonDto>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(content);
            Assert.Equal(result.Name, PokemonName);

        }

        [Fact]
        public async Task GetTranslatedPokemon_ByName_Success()
        {
            // Arrange
            var request = new { Url = $"{BaseUrl}/Translated/{PokemonName}" };

            // Act
            var response = await _httpClient.GetAsync(request.Url);
            var content = await response.Content.ReadAsStringAsync();
            var result = ContentHelper.GetRequestResult<PokemonDto>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(content);
            Assert.Equal(result.Name, PokemonName);
            Assert.Equal(result.Description, PokemonDescription);
        }

    }
}
