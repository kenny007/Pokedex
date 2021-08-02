using AutoMapper;
using Pokedex.Core.HttpClients.Pokemon;
using Pokedex.Core.HttpClients.PokemonTranslation;
using Pokedex.Core.Models;
using System.Threading.Tasks;
using Habitat = Pokedex.Core.Enums.Habitat;


namespace Pokedex.Core.Services.Pokemon {
    public class PokemonService : IPokemonService {
        private readonly IPokemonClient _pokemonClient;
        private readonly IPokemonTranslationClient _pokemonTranslationClient;
        private readonly IMapper _mapper;
        public PokemonService(IPokemonClient pokemonClient, IPokemonTranslationClient pokemonTranslationClient, IMapper mapper) {
            _pokemonClient = pokemonClient;
            _pokemonTranslationClient = pokemonTranslationClient;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<PokemonDto> GetAsync(string pokemonName) {
            var pokemon = await _pokemonClient.GetPokemonAsync(pokemonName);
            var result = _mapper.Map<PokemonDto>(pokemon.Data);
            return result;
        }

        /// <inheritdoc />
        public async Task<PokemonDto> GetTranslatedAsync(string pokemonName) {
            var pokemon = await _pokemonClient.GetPokemonAsync(pokemonName);
            var result = _mapper.Map<PokemonDto>(pokemon.Data);
            if (result.Habitat == Habitat.Cave.ToString() || result.IsLegendary) {
                result.Description = await _pokemonTranslationClient.GetAsync(result.Description, "yoda.json");
            } else {
                result.Description = await _pokemonTranslationClient.GetAsync(result.Description, "shakespeare.json");
            }

            return result;
        }
    }
}
