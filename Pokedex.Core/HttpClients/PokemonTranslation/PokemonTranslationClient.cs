using Microsoft.AspNetCore.WebUtilities;
using Pokedex.Core.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonTranslationModel = Pokedex.Core.Models.PokemonTranslation;

namespace Pokedex.Core.HttpClients.PokemonTranslation
{
    public class PokemonTranslationClient : IPokemonTranslationClient
    {
        private readonly HttpClient _httpClient;
        public PokemonTranslationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string description, string endpoint)
        {
            var queryParams = new Dictionary<string, string> {
                { "text", description.FormatString() }
            };

            var uri = QueryHelpers.AddQueryString($"{endpoint}", queryParams);

            var response = await _httpClient.GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var canDeserialize = content.TryDeserializeObject(out PokemonTranslationModel result);

                if (!canDeserialize) return description;

                return result.Contents.Translated;
            }

            return description;

        }

    }
}
