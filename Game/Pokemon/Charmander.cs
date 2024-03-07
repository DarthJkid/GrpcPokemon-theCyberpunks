namespace GrpcPokemon
{
    public class Charmander : IPokemon
    {
        public string ASCIIArt { get; set; } = CharmanderArt.Draw();
        public string Name { get; set; } = "Charmander";
        public PokemonInfo.Type Type { get; set; } = PokemonInfo.Type.Fire;
        public int Level { get; set; } = 1;
        public int Health { get; set; } = 100;
        public List<Attacks> Attacks { get; set; } = new List<Attacks> { 
            new Attacks { Name = "Tackle", BaseDamage = 40 },
            new Attacks { Name = "Vine Whip", BaseDamage = 45},
            new Attacks { Name = "Razor Leaf", BaseDamage = 55},
            new Attacks { Name = "Take Down", BaseDamage = 90}


        };
    public string DateOfCapture { get; set; } = DateTime.Now.ToString();
        public int Defense { get; set; } = 50;
    }
}
