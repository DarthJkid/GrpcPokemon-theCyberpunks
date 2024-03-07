namespace GrpcPokemon
{
    /// <summary>
    /// Produce a simple routine for a player staring 
    /// a new game
    /// </summary>
    public static class NewGame
    {
        /// <summary>
        /// Start the new game and set up the player 
        /// with a new pokemon.
        /// </summary>
        /// <returns>A new user object, with chosen pokemon</returns>
        public static CurrentUser Start()
        {
            Console.Clear();
            return GetNewUser();
        }

        /// <summary>
        /// Initialise a new user and assign basic information
        /// </summary>
        /// <returns></returns>
        private static CurrentUser GetNewUser()
        {
            PretendLoadAnimation();
            return ApplyPlayerChoices();
        }

        /// <summary>
        /// Simulate a "load" by flashing the loading text. 
        /// While we don't need to "load" here, the old Pokemon 
        /// games had a similar screen.
        /// </summary>
        private static void PretendLoadAnimation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleDisplay.BlinkText("Loading...", 100);
            Console.Clear();
        }

        /// <summary>
        /// Get the users choice of name and starter pokemon
        /// </summary>
        /// <returns>The current user object</returns>
        private static CurrentUser ApplyPlayerChoices()
        {
            CurrentUser user = new CurrentUser();

            // Get the new players name
            ConsoleDisplay.WriteTextInCentre("Trainer, what is your name?");
            user.UserName = Console.ReadLine();

            // Let the player chose their first pokemon
            ChosePokemon(PokemonChoices(), ref user);

            return user;
        }

        /// <summary>
        /// Display the pokemon choice menu
        /// </summary>
        /// <param name="toDisplay">the list of pokemon</param>
        /// <param name="user">The user object</param>
        public static void ChosePokemon(List<MenuItems> toDisplay, ref CurrentUser user)
        {
            int index = 0;
            ConsoleDisplay.DisplayGenericMenu(toDisplay, ref index, new OptionalText { PrimiaryText = "Choose your starter Pokemon" });

            IPokemon chosenPokemon = toDisplay[index].Chosen;

            user.OwnedPokemon.Add(chosenPokemon);

            DisplayChosenPokemon(chosenPokemon);
        }

        /// <summary>
        /// Display the chosen pokemon to the user
        /// </summary>
        /// <param name="chosenPokemon">the pokemon to display</param>
        private static void DisplayChosenPokemon(IPokemon chosenPokemon)
        {
            ConsoleDisplay.WriteTextInCentre("You have chosen...");
            Console.ForegroundColor = ConsoleDisplay.GetColourFromPokemon(chosenPokemon);
            ConsoleDisplay.WriteTextInCentre(chosenPokemon.ASCIIArt.ToString());
            Console.ResetColor();
            Console.ReadLine();
        }

        /// <summary>
        /// Produce a list of the starter pokemon
        /// </summary>
        /// <returns>A list of starter pokemon and their ID</returns>
        private static List<MenuItems> PokemonChoices()
        {
            return new List<MenuItems>
{
                  new MenuItems("Bulbasaur", new Bulbasaur()),
              new MenuItems("Squirtle", new Squirtle()),
              new MenuItems("Charmander", new Charmander()),
            };
        }
    }
}

