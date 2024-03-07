namespace GrpcPokemon
{
  /// <summary>
  /// Store menu choices
  /// </summary>
  public class MenuItems
  {
    public string Name { get; }
    public Action Selected { get; }
    public Func<CurrentUser> User { get; }
    public IPokemon Chosen { get; }

    /// <summary>
    /// A menu item accepting an action
    /// </summary>
    /// <param name="name">The name on the menu</param>
    /// <param name="selected">The action</param>
    public MenuItems(string name, Action selected)
    {
      Name = name;
      Selected = selected;
    }

    /// <summary>
    /// A menu item accepting a Func
    /// </summary>
    /// <param name="name">The name on the menu</param>
    /// <param name="selected">The function</param>
    public MenuItems(string name, Func<CurrentUser> selected)
    {
      Name = name;
      User = selected;
    }

    /// <summary>
    /// A menu item accepting a pokemon
    /// </summary>
    /// <param name="name">The name on the menu</param>
    /// <param name="chosen">The chosen pokemon</param>
    public MenuItems(string name, IPokemon chosen)
    {
      Name = name;
      Chosen = chosen;
    }
  }
}
