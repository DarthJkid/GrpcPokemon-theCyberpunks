namespace GrpcPokemon
{
  /// <summary>
  /// Overall control of the game
  /// </summary>
  public class PokemonManager
  {
    private CurrentUser _currentUser = new CurrentUser();

    /// <summary>
    /// Initialise overall control of the game and menu's.
    /// </summary>
    public PokemonManager()
    {
      Start.Display(ref _currentUser);

      if(SuccessfulUserCreation(_currentUser.UserName))
      {
        if(UserSaved(_currentUser.UserName) is not true)
        {
          SaveGame.CreateSave(_currentUser);
        }
        StartGame();
      }
      else
      {
        Start.Display(ref _currentUser);
      }
    }

    /// <summary>
    /// Check to see if the username is an empty string. 
    /// If it is an empty string, we know the new game / load
    /// has not worked.
    /// </summary>
    /// <param name="name">The name to check</param>
    /// <returns>True, if a name exists and a user is created</returns>
    private static bool SuccessfulUserCreation(string name) => name is not "";

    /// <summary>
    /// Check if the current user already has a save file 
    /// on the local file system.
    /// </summary>
    /// <param name="name">The user to look for</param>
    /// <returns>True, if the save already exists</returns>
    private static bool UserSaved(string name) => LoadGame.UserExistsOnFileSystem(name);

    /// <summary>
    /// Now a save has been created or loaded, 
    /// start the game by showing the main game menu.
    /// </summary>
    private static void StartGame() => ContinueGame.DisplayGameMenu();

    /// <summary>
    /// Receive damage from an opponent via gRPC
    /// </summary>
    /// <returns>The damage done</returns>
    /// <exception cref="NotImplementedException"></exception>
    //public DamageDone RecieveDamage()
    //{
    //  throw new NotImplementedException();
    //}
  }
}
