namespace Pokedex.Core.Models {
    public class PokemonDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public bool IsLegendary { get; set; }

        public string Habitat { get; set; }
    }
}
