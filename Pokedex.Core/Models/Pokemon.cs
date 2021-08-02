using System.Collections.Generic;

namespace Pokedex.Core.Models {
    public class Pokemon {
        public string Name { get; set; }
        public bool Is_Legendary { get; set; }

        public Habitat Habitat { get; set; }
        public IEnumerable<FlavorTextEntries> Flavor_Text_Entries { get; set; }
    }

    public class Habitat {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class FlavorTextEntries {
        public string Flavor_Text { get; set; }
    }
}
