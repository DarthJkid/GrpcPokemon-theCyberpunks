using GrpcPokemon.Game.Ascii_Art.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcPokemon.Game.Pokemon
{
    internal class Mewtwo : IPokemon
    {
        public string ASCIIArt { get; set; } = MewtwoArt.Draw();
        public string Name { get; set; } = "MewTwo";
        public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Psychic;
        public int Level { get; set; } = 100;
        public int Health { get; set; } = 106;
        public int Defense { get; set; } = 90;
        public List<Attacks> Attacks { get; set; } = new List<Attacks> {
            new Attacks {Name = "Future Sight", BaseDamage = 120 },
            new Attacks { Name = "Psystrike", BaseDamage = 100 },
            new Attacks { Name = "Psychic", BaseDamage = 90},
            new Attacks { Name = "Aura Sphere", BaseDamage = 80}


        };
        public string DateOfCapture { get; set; }
    }
}
