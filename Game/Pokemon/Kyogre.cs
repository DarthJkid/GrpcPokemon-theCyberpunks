using GrpcPokemon.Game.Ascii_Art.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcPokemon.Game.Pokemon
{
    internal class Kyogre : IPokemon
    {
        public string ASCIIArt { get; set; } = KyogreArt.Draw();
        public string Name { get; set; } = "Kyogre";
        public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Water;
        public int Level { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Defense { get; set; } = 90;
        public List<Attacks> Attacks { get; set; } = new List<Attacks> {
            new Attacks {Name = "Water Spout", BaseDamage = 150 },
            new Attacks { Name = "Double Edge", BaseDamage = 120 },
            new Attacks { Name = "Hydrop Pump", BaseDamage = 110},
            new Attacks { Name = "Origin Pulse", BaseDamage = 110}


        };
        public string DateOfCapture { get; set; }
    }
}
