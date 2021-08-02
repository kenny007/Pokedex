using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.AppSettings;
using Pokedex.Core.HttpClients.Pokemon;
using Pokedex.Core.HttpClients.PokemonTranslation;
using System;

namespace Pokedex.Api.Configurations {
    /// <summary>
    /// Configuration of HTTP clients using IHttpClientFactory
    /// </summary>
    public static class HttpClientsConfiguration
    {
        /// <summary>
        /// Extension method to register http clients
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        public static void RegisterHttpClients(this IServiceCollection services, PokemonSettings settings)
        {

            services.AddHttpClient<IPokemonClient, PokemonClient>(client =>
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
            });

            services.AddHttpClient<IPokemonTranslationClient, PokemonTranslationClient>(client =>
            {
                client.BaseAddress = new Uri(settings.TranslationUrl);
            });
        }
    }
}
