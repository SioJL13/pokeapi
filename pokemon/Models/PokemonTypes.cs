using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace pokemon.Models
{
    public class PokemonTypes
    {
        public List<TypeData> Types { get; set; }
        
    }

    public class TypeData
    {
        public int Slot { get; set; }
        public TypeInfo Type { get; set; }
        
    }

    public class TypeInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
