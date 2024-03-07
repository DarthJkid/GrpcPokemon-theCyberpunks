using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcPokemon.Game.Pokemon
{
    internal class Pikachu : IPokemon
    {
        public string ASCIIArt { get; set; } = PikachuArt.Draw();
        public string Name { get; set; } = "Pikachu";
        public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Electric;
        public int Level { get; set; } = 1;
        public int Health { get; set; } = 35;
        public List<Attacks> Attacks { get; set; } = new List<Attacks> {
            new Attacks {Name = "Thunder", BaseDamage = 110},
            new Attacks {Name = "Iron Tail", BaseDamage = 100},
            new Attacks {Name = "Thunderbolt", BaseDamage = 90},
            new Attacks {Name = "Discharge", BaseDamage = 80}
        
        };
        public string DateOfCapture { get; set; } = DateTime.Now.ToString();
        public int Defense { get; set; } = 50;
    }
}
