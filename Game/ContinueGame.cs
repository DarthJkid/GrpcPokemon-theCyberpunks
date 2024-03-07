namespace GrpcPokemon
{
  /// <summary>
  /// Display the main game menu
  /// </summary>
  public static class ContinueGame
  {
    /// <summary>
    /// Show the main game menu
    /// </summary>
    /// <exception cref="NotImplementedException">To be completed</exception>
    public static void DisplayGameMenu()
    {
      ShowLogo();
      int choice = 0;
      ConsoleDisplay.DisplayGenericMenu(GameChoices(), ref choice, new OptionalText() { PrimiaryText = PokemonLogo.Draw(), TextColour = ConsoleColor.Yellow });
    }

    /// <summary>
    /// Show the pokemon logo and flash it while the menu "loads"
    /// </summary>
    private static void ShowLogo()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Yellow;
      ConsoleDisplay.BlinkText(PokemonLogo.Draw(), 100);
    }

    /// <summary>
    /// The main game menu options
    /// </summary>
    /// <returns>A list of the main game menu options</returns>
    private static List<MenuItems> GameChoices()
    {
            return new List<MenuItems> {
              new MenuItems("View Pokemon", ViewPokemon.View()),
              new MenuItems("View Pokedex", ViewPokedex.View()),
              new MenuItems("Explore", Explore.ExploreWorld()),
              new MenuItems("Battle", Battle.StartBattle()),
            };
    }
  }
}
