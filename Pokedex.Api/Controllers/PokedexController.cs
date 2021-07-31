using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Services.Pokemon;

namespace Pokedex.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokedexController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Returns basic pokemon information
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string pokemonName) {
            return Ok();
        }

        /// <summary>
        /// Returns pokemon description with translation
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        [HttpGet("Translated/{PokemonName}")]
        public async Task<IActionResult> GetTranslated(string pokemonName) {
            return Ok();
        }
    }
}
