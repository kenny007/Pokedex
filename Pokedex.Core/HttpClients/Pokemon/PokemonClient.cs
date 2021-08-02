using Newtonsoft.Json.Serialization;
using Pokedex.Core.Common;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonModel = Pokedex.Core.Models.Pokemon;

namespace Pokedex.Core.HttpClients.Pokemon {
    public class PokemonClient : IPokemonClient {
        private readonly HttpClient _httpClient;

        public PokemonClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<OperationResult<PokemonModel>> GetPokemonAsync(string pokemonName)
        {
            var response = await _httpClient.GetAsync($"pokemon-species/{pokemonName}");

            var content = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var canDeserialize = content.TryDeserializeObject(out PokemonModel result);

                if (!canDeserialize) return OperationResult.Fail<PokemonModel>();

                return OperationResult.Ok(result);
            }
            else
            {
                var canDeserialize = content.TryDeserializeObject(out ErrorContext error);

                if (!canDeserialize) return OperationResult.Fail<PokemonModel>();

                return OperationResult.Fail<PokemonModel>(error.ToString());
            }

        }

    }
}
