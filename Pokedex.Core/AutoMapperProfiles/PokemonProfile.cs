using AutoMapper;
using Pokedex.Core.Models;
using System.Linq;

namespace Pokedex.Core.AutoMapperProfiles {
    /// <summary>
    /// Basic pokemon profile
    /// </summary>
    public class PokemonProfile : Profile {
        public PokemonProfile()
        {
            CreateMap<Pokemon, PokemonDto>()
                .ForMember(d => d.IsLegendary, map => map.MapFrom(h => h.Is_Legendary))
                .ForMember(d => d.Habitat, map => map.MapFrom(h => h.Habitat.Name))
                .ForMember(d => d.Description, m => m.MapFrom(h => h.Flavor_Text_Entries.FirstOrDefault().Flavor_Text));
        }
    }
}
