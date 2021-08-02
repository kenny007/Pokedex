using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pokedex.Core.Enums {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Habitat {
        [EnumMember(Value = "cave")]
        Cave
    }
}
