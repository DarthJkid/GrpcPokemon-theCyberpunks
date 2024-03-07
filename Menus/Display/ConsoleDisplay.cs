namespace GrpcPokemon
{
  /// <summary>
  /// Provide generic methods used by the console 
  /// for display and control of the game
  /// </summary>
  public static class ConsoleDisplay
  {
    /// <summary>
    /// Write a string to the center of the console
    /// </summary>
    /// <param name="textToWrite">The string to write</param>
    public static void WriteTextInCentre(string textToWrite) => Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (textToWrite.Length / 2)) + "}", textToWrite));

    /// <summary>
    /// Get the console colour from the pokemon Type
    /// </summary>
    /// <param name="pokemon">The pokemon to check</param>
    /// <returns>The console colour</returns>
    public static ConsoleColor GetColourFromPokemon(IPokemon pokemon)
    {
      return pokemon.Type switch
      {
        PokemonInfo.Type.Grass => ConsoleColor.Green,
        PokemonInfo.Type.Fire => ConsoleColor.Red,
        PokemonInfo.Type.Water => ConsoleColor.Blue,
        _ => ConsoleColor.White
      };
    }


    /// <summary>
    /// Produce a menu that accepts a list of file info 
    /// objects.
    /// </summary>
    /// <param name="saves">The user save files</param>
    /// <param name="index">The current pos of the menu item being selected.</param>
    public static void ChooseLoad(List<FileInfo> saves, ref int index)
    {
      do
      {
        WriteLoadMenu(saves, index);
      }
      while(Selected(saves, ref index) is not true);
    }

    /// <summary>
    /// Display a generic menu that can handle 
    /// a list of menu items
    /// </summary>
    /// <param name="menuItems">A list of menu items</param>
    /// <param name="index">The current menu index</param>
    /// <param name="optionalText">Optional menu text</param>
    public static void DisplayGenericMenu(List<MenuItems> menuItems, ref int index, OptionalText optionalText = null)
    {
      do
      {
        WriteGenericMenu(menuItems, menuItems[index], optionalText);
      }
      while(Selected(menuItems, ref index) is not true);
    }

    /// <summary>
    /// Display a generic menu, but allow choice to be assigned 
    /// to the current user.
    /// </summary>
    /// <param name="toDisplay">The menu items to display</param>
    /// <param name="user">The user object to assign to</param>
    /// <param name="optionalText">Optional menu text</param>
    public static void DisplayUserMenu(List<MenuItems> toDisplay, ref CurrentUser user, OptionalText optionalText = null)
    {
      int index = 0;
      do
      {
        WriteGenericMenu(toDisplay, toDisplay[index], optionalText);
      }
      while(Selected(toDisplay, ref index) is not true);
      user = toDisplay[index].User.Invoke();
    }

    /// <summary>
    /// Navigate through the menu options
    /// </summary>
    /// <typeparam name="T">The type of menu</typeparam>
    /// <param name="toDisplay">The items to display</param>
    /// <param name="index">The current index</param>
    /// <returns>True, if an option is chosen</returns>
    private static bool Selected<T>(List<T> toDisplay, ref int index)
    {
      bool itemSelected = false;
      ConsoleKeyInfo keyinfo;
      keyinfo = Console.ReadKey();

      if(keyinfo.Key == ConsoleKey.DownArrow)
      {
        DownArrow(toDisplay, ref index);
      }
      if(keyinfo.Key == ConsoleKey.UpArrow)
      {
        UpArrow(ref index);
      }
      if(keyinfo.Key == ConsoleKey.Enter)
      {
        itemSelected = true;
      }
      return itemSelected;
    }

    /// <summary>
    /// Handle a user down arrow press
    /// </summary>
    /// <typeparam name="T">The list type</typeparam>
    /// <param name="item">The menu items</param>
    /// <param name="index">The current position</param>
    private static void DownArrow<T>(List<T> item, ref int index)
    {
      if(MaxMenuItems(index) < item.Count)
      {
        index++;
      }
      Reset();
    }

    /// <summary>
    /// Get the max number of menu items
    /// </summary>
    /// <param name="index">The current selection</param>
    /// <returns>The max number of menu items in the list</returns>
    private static int MaxMenuItems(int index) => index + 1;

    /// <summary>
    /// Handle a user up arrow press
    /// </summary>
    /// <param name="index">The current position</param>
    private static void UpArrow(ref int index)
    {
      if(MinMenuItems(index) >= 0)
      {
        index--;
      }
      Reset();
    }

    /// <summary>
    /// Get the min menu items in the list
    /// </summary>
    /// <param name="index">The current position</param>
    /// <returns>The min menu items</returns>
    private static int MinMenuItems(int index) => index - 1;

    /// <summary>
    /// Clear the menu
    /// </summary>
    private static void Reset()
    {
      Console.Clear();
      Console.ResetColor();
    }

    /// <summary>
    /// Write the load menu to the screen
    /// </summary>
    /// <param name="saveFiles">The current save files</param>
    /// <param name="index">The current choice</param>
    public static void WriteLoadMenu(List<FileInfo> saveFiles, int index)
    {
      Console.Clear();
      WriteTextInCentre("Chose your game save file to load...");
      Console.WriteLine(Environment.NewLine);

      foreach(FileInfo save in saveFiles)
      {
        if(saveFiles[index].Name == save.Name)
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.WriteLine(Environment.NewLine);
        WriteTextInCentre(save.Name);
        Console.ResetColor();
      }
    }

    /// <summary>
    /// Write a menu to the screen
    /// </summary>
    /// <param name="options">The menu items to write</param>
    /// <param name="selectedOption">The selected item</param>
    public static void WriteGenericMenu(List<MenuItems> options, MenuItems selectedOption, OptionalText optionalText)
    {
      WriteOptionalText(optionalText);

      foreach(MenuItems option in options)
      {
        if(option == selectedOption)
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }
        WriteTextInCentre($"{option.Name}{Environment.NewLine}");
        Console.ResetColor();
      }
    }

    /// <summary>
    /// Write the optional text to the screen
    /// </summary>
    /// <param name="optionalText">The optional text</param>
    private static void WriteOptionalText(OptionalText optionalText)
    {
      if(optionalText is not null && optionalText.PrimiaryText is not "")
      {
        Console.ForegroundColor = optionalText.TextColour;
        WriteTextInCentre(optionalText.PrimiaryText);
        WriteTextInCentre(optionalText.SecondaryText);
        Console.ResetColor();
      }
    }

    /// <summary>
    /// Blink text on the screen
    /// </summary>
    /// <param name="text">The text to display</param>
    /// <param name="delay">How long to wait between blinks</param>
    /// <param name="toBlink">The number of times to blink</param>
    public static void BlinkText(string text, int delay, int toBlink = 10)
    {
      bool visible = true;

      for(int i = 0; i < toBlink; i++)
      {
        Console.Clear();
        WriteTextInCentre(visible ? text : new string(' ', text.Length));
        Thread.Sleep(delay);
        visible = !visible;
      }
    }
  }
}
