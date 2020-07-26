using System;
using System.Collections.Generic;

namespace pokemon.Models
{
    public class DamageRelations
    {
        public DamageRelationData Damage_Relations { get; set; }
    }

    public class DamageRelationData
    {
        public List<DamageData> No_Damage_To { get; set; }
        public List<DamageData> Half_Damage_To { get; set; }
        public List<DamageData> Double_Damage_To { get; set; }
        public List<DamageData> No_Damage_From { get; set; }
        public List<DamageData> Half_Damage_From { get; set; }
        public List<DamageData> Double_Damage_From { get; set; }
    }

    public class DamageData
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
