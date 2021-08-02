namespace Pokedex.Core.Models {
    public class PokemonTranslation {
        public PokemonContent Contents { get; set; }
    }

    public class PokemonContent {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }

}
