using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.AppSettings;
using Pokedex.Core.HttpClients.Pokemon;
using Pokedex.Core.HttpClients.PokemonTranslation;

namespace Pokedex.Api.Configurations {
    /// <summary>
    /// Configuration of HTTP clients using IHttpClientFactory
    /// </summary>
    public static class HttpClientsConfiguration {
        /// <summary>
        /// Add HTTP clients to DI container
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration</param>
        public static IServiceCollection RegisterHttpClients(this IServiceCollection services, IConfiguration configuration) {
            var pokemonSettings = configuration.GetSection(nameof(PokemonSettings)).Get<PokemonSettings>();
            var translationSettings = configuration.GetSection(nameof(PokemonTranslationSettings)).Get<PokemonTranslationSettings>();

            services.AddHttpClient<IPokemonClient, PokemonClient>(client => {
                client.BaseAddress = new Uri(pokemonSettings.BaseUrl);
            });

            services.AddHttpClient<IPokemonTranslationClient, IPokemonTranslationClient>(client =>
            {
                client.BaseAddress = new Uri(translationSettings.BaseUrl);
            });

            return services;
        }
    }
}
