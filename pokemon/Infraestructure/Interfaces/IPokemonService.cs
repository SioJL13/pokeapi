using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using pokemon.Models;

namespace pokemon.Infraestructure.Interfaces
{
    public interface IPokemonService
    {
        Task<JObject> GetPokemonAdvantageAsync(PokeAdvantage pokes);
        Task<List<MovesData>> GetPokemonMoves(PokeMoves pokeMoves);
    }
}
