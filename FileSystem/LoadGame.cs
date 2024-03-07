using System.Runtime.Serialization;
using System.Xml;

namespace GrpcPokemon
{
    /// <summary>
    /// Load a user save file from the file system
    /// </summary>
    public static class LoadGame
    {
        /// <summary>
        /// Find the user save files and load the 
        /// users choice of save. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static CurrentUser Load()
        {
            CurrentUser currentUser = new CurrentUser();

            DisplayMenu(GetSaveFiles(), ref currentUser);

            return currentUser;
        }

        /// <summary>
        /// Display the load menu and let the user chose 
        /// the save file they want to load.
        /// </summary>
        /// <param name="saves">All the save files</param>
        /// <param name="user">the user object to laod to</param>
        public static void DisplayMenu(List<FileInfo> saves, ref CurrentUser user)
        {
            if (saves.Count > 0)
            {
                int index = 0;
                ConsoleDisplay.ChooseLoad(saves, ref index);
                LoadUserSave(saves[index].FullName, ref user);
            }
            else
            {
                throw new Exception("No saves found - How should we handle this?");
            }
        }

        /// <summary>
        /// Load the user save that has been selected by the 
        /// player.
        /// </summary>
        /// <param name="filePath">The file path of the save</param>
        /// <param name="user">The user object to load to</param>
        private static void LoadUserSave(string filePath, ref CurrentUser user)
        {
            //Type[] extraTypes = Type[typeof(List<IPokemon>), typeof(Bulbasaur), typeof(Charmander), typeof(Squirtle)];

            Type[] extraTypes = new Type[4];
            extraTypes[0] = typeof(List<IPokemon>);
            extraTypes[1] = typeof(List<Bulbasaur>);
            extraTypes[2] = typeof(List<Charmander>);
            extraTypes[3] = typeof(List<Squirtle>);



            DataContractSerializer conSerializer = new DataContractSerializer(typeof(CurrentUser), extraTypes);
            using FileStream fileStream = new FileStream(filePath, FileMode.Open);
            using XmlDictionaryReader fileContents = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            user = (CurrentUser)conSerializer.ReadObject(fileContents);
        }


        /// <summary>
        /// Find all of the save files on the file system
        /// </summary>
        /// <returns>A list of file info objects, for the saves</returns>
        private static List<FileInfo> GetSaveFiles()
        {
            List<FileInfo> saveFiles = new List<FileInfo>();

            foreach (string save in GetAllSaveFiles())
            {
                FileInfo file = new FileInfo(save);
                saveFiles.Add(file);
            }
            return saveFiles;
        }

        /// <summary>
        /// Check to see if a user currently has a save 
        /// file on the file system.
        /// </summary>
        /// <param name="user">The user to search for</param>
        /// <returns>True, if the user has a save file.</returns>
        public static bool UserExistsOnFileSystem(string user) => GetAllSaveFiles().Contains(new FileInfo($"{Location.s_filePath}/{user}").FullName + Location.FILE_TYPE);

        /// <summary>
        /// Get all of the game save files
        /// </summary>
        /// <returns>An array of save files</returns>
        private static string[] GetAllSaveFiles() => Directory.GetFiles(Location.s_filePath);
    }
}
