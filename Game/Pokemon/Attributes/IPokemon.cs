using System.Runtime.Serialization;

namespace GrpcPokemon
{
  public interface IPokemon
  {
    public string ASCIIArt { get; set; }

    public string Name { get; set; }

    public PokemonInfo.Type Type { get; set; }

    public int Level { get; set; }

    public int Health { get; set; }

    public int Defense { get; set; }

    public List<Attacks> Attacks { get; set; }

    public string DateOfCapture { get; set; }
  }
}
