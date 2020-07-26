using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokemon.Infraestructure.Interfaces;
using pokemon.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pokemon.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get(PokeAdvantage pokes)
        {
            var res = await _pokemonService.GetPokemonAdvantageAsync(pokes);

            return Ok(res);
        }

        [HttpPost]
        [Route("/moves")]
        public async Task<IActionResult> GetMoves([FromBody] PokeMoves pokes)
        {
            var res = await _pokemonService.GetPokemonMoves(pokes);

            return Ok(res);
        }

    }
}
