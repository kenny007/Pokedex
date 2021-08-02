﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Models.Requests;
using Pokedex.Core.Services.Pokemon;

namespace Pokedex.Api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase {
        private readonly IPokemonService _pokemonService;
        public PokedexController(IPokemonService pokemonService) {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Returns basic pokemon information
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string pokemonName) {
            var result = await _pokemonService.GetAsync(pokemonName);
            return Ok(result);
        }

        /// <summary>
        /// Returns pokemon description with translation
        /// </summary>
        /// <param name="nameParam"></param>
        /// <returns></returns>
        [HttpGet("Translated/{PokemonName}")]
        public async Task<IActionResult> GetTranslated([FromRoute] PokemonNameParam nameParam) {
            var result = await _pokemonService.GetTranslatedAsync(nameParam.PokemonName);
            return Ok(result);
        }
    }
}
