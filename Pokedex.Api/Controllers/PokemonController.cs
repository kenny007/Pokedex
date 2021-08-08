using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Models;
using Pokedex.Core.Models.Requests;
using Pokedex.Core.Services.Pokemon;

namespace Pokedex.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Returns basic pokemon information
        /// </summary>
        /// <param name="nameParam"></param>
        /// <returns></returns>
        [HttpGet("{PokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] PokemonNameParam nameParam)
        {
            if (string.IsNullOrWhiteSpace(nameParam.PokemonName)) return BadRequest();
            var result = await _pokemonService.GetAsync(nameParam.PokemonName);
            return Ok(result);
        }

        /// <summary>
        /// Returns pokemon description with translation
        /// </summary>
        /// <param name="nameParam"></param>
        /// <returns></returns>
        [HttpGet("Translated/{PokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTranslated([FromRoute] PokemonNameParam nameParam)
        {
            if (string.IsNullOrWhiteSpace(nameParam.PokemonName)) return BadRequest();
            var result = await _pokemonService.GetTranslatedAsync(nameParam.PokemonName);
            return Ok(result);
        }
    }
}
