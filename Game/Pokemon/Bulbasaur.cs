namespace GrpcPokemon
{
  public class Bulbasaur : IPokemon
  {
    public string ASCIIArt { get; set; } = BulbasaurArt.Draw();
    public string Name { get; set; } = "Bulbasaur";
    public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Grass;
    public int Level { get; set; } = 100;
    public int Health { get; set; } = 100;


        public List<Attacks> Attacks { get; set; } = new List<Attacks> { 
            new Attacks {Name = "Solar Beam", BaseDamage = 120},
            new Attacks {Name = "Power Whip", BaseDamage = 120},
            new Attacks {Name = "Take Down", BaseDamage = 93},
            new Attacks {Name = "Seed Bomb", BaseDamage = 87}
        };
    public string DateOfCapture { get; set; } = DateTime.Now.ToString();
        public int Defense { get; set; } = 50;
    }
}
