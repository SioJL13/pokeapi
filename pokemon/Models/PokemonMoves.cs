using System;
using System.Collections.Generic;

namespace pokemon.Models
{
    public class PokemonMoves
    {
        public List<MovesData> Moves { get; set; }
    }

    public class MovesData
    {
        public MoveInfo Move { get; set; }
    }

    public class MoveInfo
    {
        public string Name { get; set; }
    }
}
