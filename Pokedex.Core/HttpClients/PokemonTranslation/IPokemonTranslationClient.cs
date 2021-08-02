using System.Threading.Tasks;

namespace Pokedex.Core.HttpClients.PokemonTranslation {
    public interface IPokemonTranslationClient {
        Task<string> GetAsync(string pokemonName, string endpoint);
    }
}
