using Pokedex.Core.Models;
using System.Threading.Tasks;

namespace Pokedex.Core.Services.Pokemon
{
    public interface IPokemonService
    {

        /// <summary>
        /// Get pokemon by pokemon name
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        Task<PokemonDto> GetAsync(string pokemonName);

    }
}
