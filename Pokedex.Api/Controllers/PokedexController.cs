using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase {
        public PokedexController() {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(string pokemonName) {
            return Ok();
        }

        [HttpGet("Translated/{PokemonName}")]
        public async Task<IActionResult> GetTranslated(string pokemonName) {
            return Ok();
        }
    }
}
