namespace GrpcPokemon
{
  /// <summary>
  /// Object containing optional text and formatting 
  /// to be passed to a menu control.
  /// </summary>
  public class OptionalText
  {
    public string PrimiaryText { get; set; } = "";

    public string SecondaryText { get; set; } = "";

    public ConsoleColor TextColour { get; set; } = ConsoleColor.White;
  }
}
