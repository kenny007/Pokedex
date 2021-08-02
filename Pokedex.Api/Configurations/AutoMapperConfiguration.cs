using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.AutoMapperProfiles;

namespace Pokedex.Api.Configurations
{
    /// <summary>
    /// Mapper registration configs
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Extension method to register AutoMapper with specified configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = GetConfiguration();

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static MapperConfiguration GetConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PokemonProfile());
            });

            return mappingConfig;
        }
    }
}
