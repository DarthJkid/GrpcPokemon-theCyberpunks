namespace GrpcPokemon
{
  public class Squirtle : IPokemon
  {
    public string ASCIIArt { get; set; } = SquirtleArt.Draw();
    public string Name { get; set; } = "Squirtle";
    public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Water;
    public int Level { get; set; } = 1;
    public int Health { get; set; } = 100;
    public List<Attacks> Attacks { get; set; } = new List<Attacks> {
        new Attacks { Name = "Tail Whip", BaseDamage = 5},
        new Attacks { Name = "Wave Crash", BaseDamage = 120},
        new Attacks { Name = "Hydro Pump", BaseDamage = 110},
        new Attacks { Name = "Aqua Tail", BaseDamage = 90}
    };
        public string DateOfCapture { get; set; } = DateTime.Now.ToString();
     public int Defense { get; set; } = 50;
    }
}
