namespace GrpcPokemon
{
  /// <summary>
  /// Start the game and show the new / load 
  /// options. 
  /// </summary>
  public static class Start
  {
    private static string _version = "gRPC Pokemon v1.0.0";

    /// <summary>
    /// Display the start menu.
    /// </summary>
    public static void Display(ref CurrentUser user)
    {
      ConsoleDisplay.DisplayUserMenu(MenuItems(), ref user, Logo());
    }

    /// <summary>
    /// Create the logo as optional text and 
    /// apply formatting.
    /// </summary>
    private static OptionalText Logo()
    {
      return new OptionalText
      {
        PrimiaryText = $"{PokemonLogo.Draw()}{Environment.NewLine}",
        SecondaryText = $"{_version}{Environment.NewLine}",
        TextColour = ConsoleColor.Yellow
      };
    }

    /// <summary>
    /// The menu items that should be loaded.
    /// </summary>
    /// <returns>A list of menu items</returns>
    private static List<MenuItems> MenuItems()
    {
return new List<MenuItems> {
              new MenuItems("New Game", () => NewGame.Start()),
              new MenuItems("Load Game", () => LoadGame.Load()),
              new MenuItems("Exit", () => Environment.Exit(0))
            };
    }
  }
}
