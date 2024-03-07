using GrpcPokemon.Game.Ascii_Art.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcPokemon.Game.Pokemon
{
    internal class Groudon
    {
        public string ASCIIArt { get; set; } = GroudonArt.Draw();
        public string Name { get; set; } = "Groudon";
        public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Stone;
        public int Level { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Defence { get; set; } = 140;

        public List<Attacks> Attacks { get; set; } = new List<Attacks> {
            new Attacks {Name = "Eruption", BaseDamage = 150},
            new Attacks {Name = "Solar Beam", BaseDamage = 120},
            new Attacks {Name = "Precipice Blades", BaseDamage = 120},
            new Attacks {Name = "Fire Blast", BaseDamage = 110}
        };
        public string DateOfCapture { get; set; } = DateTime.Now.ToString();
    }
}