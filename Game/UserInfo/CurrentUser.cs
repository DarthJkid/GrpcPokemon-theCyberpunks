namespace GrpcPokemon
{
  public class CurrentUser
  {
    public string UserName { get; set; } = string.Empty;

    public List<IPokemon> OwnedPokemon { get; set; } = new List<IPokemon>();

    public int NumberOfVictories { get; set; } = 0;
  }
}
