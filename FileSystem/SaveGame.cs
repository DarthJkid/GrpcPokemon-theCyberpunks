using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml;

namespace GrpcPokemon
{
  /// <summary>
  /// Class that allows for the creation of a 
  /// new save and the update of a save file 
  /// mid game.
  /// </summary>
  public static class SaveGame
  {
    /// <summary>
    /// Create a save file on the file system for 
    /// the newly created player.
    /// </summary>
    /// <param name="user">The user to save</param>
    /// <returns>True, if the save file is created successfully</returns>
    public static bool CreateSave(CurrentUser user)
    {
      Directory.CreateDirectory(Location.s_filePath);
      bool creationSuccess = true;
      try
      {
        XDocument storageDoc = new XDocument();
        string path = $"{Location.s_filePath}/{user.UserName}{Location.FILE_TYPE}";
        if(!File.Exists(path))
        {
          storageDoc.Add(ToXML(user));
          storageDoc.Save(path);
        }
      }
      catch(Exception)
      {
        creationSuccess = false;
      }
      return creationSuccess;
    }

    /// <summary>
    /// Convert the object to XML to save to the file system
    /// </summary>
    /// <param name="user">The user to save</param>
    /// <returns>The user object as XML</returns>
    public static XElement ToXML(CurrentUser user)
    {
      Type remoteServerType = typeof(CurrentUser);
            Type[] extraTypes = new Type[4];
            extraTypes[0] = typeof(List<IPokemon>);
            extraTypes[1] = typeof(List<Bulbasaur>);
            extraTypes[2] = typeof(List<Charmander>);
            extraTypes[3] = typeof(List<Squirtle>); 
            
            //[typeof(List<IPokemon>), typeof(Bulbasaur), typeof(Charmander), typeof(Squirtle)];

      DataContractSerializer serializer = new DataContractSerializer(remoteServerType, extraTypes);
      StringWriter xmlAsString = new StringWriter();
      XmlTextWriter xmlLine = new XmlTextWriter(xmlAsString);
      serializer.WriteObject(xmlLine, user);
      return XElement.Parse(xmlAsString.ToString());
    }

    /// <summary>
    /// Save the new XML file to the file system
    /// </summary>
    /// <param name="user">The user to save</param>
    public static void Save(CurrentUser user)
    {
      XDocument settingsDoc = new XDocument();
      string path = $"{Location.s_filePath}{user.UserName}{Location.FILE_TYPE}";
      settingsDoc.Add(ToXML(user));
      settingsDoc.Save(path);
    }
  }
}
