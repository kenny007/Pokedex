using AutoMapper;
using Pokedex.Core.HttpClients.Pokemon;
using Pokedex.Core.Models;
using System.Threading.Tasks;

namespace Pokedex.Core.Services.Pokemon {
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonClient _pokemonClient;
        private readonly IMapper _mapper;
        public PokemonService(IPokemonClient pokemonClient, IMapper mapper)
        {
            _pokemonClient = pokemonClient;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<PokemonDto> GetAsync(string pokemonName)
        {
            var pokemon = await _pokemonClient.GetPokemonAsync(pokemonName);
            var mappedPokemon = _mapper.Map<PokemonDto>(pokemon.Data);
            return mappedPokemon;
        }
    }
}
