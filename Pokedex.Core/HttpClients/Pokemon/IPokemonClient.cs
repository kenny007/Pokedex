using System.Threading.Tasks;
using Pokedex.Core.Common;
using PokemonModel = Pokedex.Core.Models.Pokemon;

namespace Pokedex.Core.HttpClients.Pokemon {
    public interface IPokemonClient {
        Task<OperationResult<PokemonModel>> GetPokemonAsync(string pokemonName);
    }
}
