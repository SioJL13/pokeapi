using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pokemon.Infraestructure.Interfaces;
using pokemon.Models;

namespace pokemon.Infraestructure.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IConfiguration Configuration;
        public PokemonService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<JObject> GetPokemonAdvantageAsync(PokeAdvantage pokes)
        {
            var firstPokeTypeData = await ObtainPokeDataAsync(pokes.FirstPoke);
            var secondPokeTypeData = await ObtainPokeDataAsync(pokes.SecondPoke);
            //TODO: handle actual list
            var firstPokeDamage = await ObtainDamageRelationAsync(firstPokeTypeData.Types[0].Type.Url);
            var secondPokeType = secondPokeTypeData.Types[0].Type.Name;

            var res = CheckDamageRelation(firstPokeDamage, secondPokeType);
            return res;
        }

        public async Task<List<MovesData>> GetPokemonMoves(PokeMoves pokeMoves)
        {
            var sizeOfPokeList = pokeMoves.Pokemons.Count;
            var firstPokeMoves = await ObtainPokeMovesDataAsync(pokeMoves.Pokemons[0]);
            var secondPokeMoves = await ObtainPokeMovesDataAsync(pokeMoves.Pokemons[1]);

            var res = firstPokeMoves.Moves.Where(x => secondPokeMoves.Moves.Any(y => y.Move.Name == x.Move.Name)).ToList();

            return res.GetRange(0, pokeMoves.AmountMoves);
        }

        private async Task<PokemonMoves> ObtainPokeMovesDataAsync(string pokemon)
        {
            var pokemonTypeData = new PokemonMoves();
            var basePokemonUrl = Configuration["PokeApiUrl"] + "pokemon/" + pokemon;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(basePokemonUrl))
                {
                    if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when obtaining pokemon type");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pokemonTypeData = JsonConvert.DeserializeObject<PokemonMoves>(apiResponse);
                }
            }
            return pokemonTypeData;
        }

        private async Task<PokemonTypes> ObtainPokeDataAsync(string pokemon)
        {
            var pokemonTypeData = new PokemonTypes();
            var basePokemonUrl = Configuration["PokeApiUrl"] + "pokemon/" + pokemon;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(basePokemonUrl))
                {
                    if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when obtaining pokemon type");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pokemonTypeData = JsonConvert.DeserializeObject<PokemonTypes>(apiResponse);
                }
            }
            return pokemonTypeData;
        }

        private async Task<DamageRelations> ObtainDamageRelationAsync(string url)
        {
            var damageRelationData = new DamageRelations();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when obtaining damage of pokemon");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    damageRelationData = JsonConvert.DeserializeObject<DamageRelations>(apiResponse);
                }
            }

            return damageRelationData;
        }

        private JObject CheckDamageRelation(DamageRelations damage, string pokeType)
        {
            var res = new JObject();
            res["Do_double_damage"] = damage.Damage_Relations.Double_Damage_To.Exists(x => x.Name == pokeType);
            res["Receive_half_damage"] = damage.Damage_Relations.Half_Damage_From.Exists(x => x.Name == pokeType);
            res["No_damage_received"] = damage.Damage_Relations.No_Damage_From.Exists(x => x.Name == pokeType);
            return res;
        }

    }
}
