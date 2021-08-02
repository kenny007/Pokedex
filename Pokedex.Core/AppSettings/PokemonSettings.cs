using Microsoft.Extensions.Configuration;

namespace Pokedex.Core.AppSettings {
    /// <summary>
    /// Pokemon settings
    /// </summary>
    public class PokemonSettings {
        public string BaseUrl { get; set; }

        public string TranslationUrl { get; set; }


        /// <summary>
        /// Gets settings section from IConfiguration
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <returns></returns>
        public static PokemonSettings GetFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(nameof(PokemonSettings)).Get<PokemonSettings>();
        }
	}
}
