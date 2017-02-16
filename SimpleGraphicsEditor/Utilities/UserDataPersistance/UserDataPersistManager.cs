namespace SimpleGraphicsEditor.Utilities.UserDataPersistance
{
    using System.IO;

    /// <summary>
    /// Represents an entity used for persist user data from the application
    /// </summary>
    public class UserDataPersistManager
    {
        /// <summary>
        /// Saves current user data from application.
        /// </summary>
        /// <typeparam name="T">Type of the object which will be persisted.</typeparam>
        /// <param name="obj">The object which will be persisted.</param>
        /// <param name="filePath">Path of the file which data will be stored.</param>
        public void Save<T>(
            T obj,
            string filePath)
        {
            var xml = SerializeData.SerializeObject<T>(obj);
            File.WriteAllText(filePath, xml);
        }

        /// <summary>
        /// Loads user data back to application.
        /// </summary>
        /// <typeparam name="T">Type of the object which will be read back from persistanc.</typeparam>
        /// <param name="filePath">Path of the file which data has stored.</param>
        /// <returns>The object persisted in to the file.</returns>
        public T Load<T>(
            string filePath)
        {
            var xml = File.ReadAllText(filePath);
            var obj = (T)DeserializeData.DeserializeObject<T>(xml);
            return obj;
        }
    }
}
