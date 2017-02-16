namespace SimpleGraphicsEditor.Utilities.UserDataPersistance
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents an entity which can be used to serialize application data to XML
    /// </summary>
    public static class SerializeData
    {
        /// <summary>
        /// A string constant which holds the namespace of the application models.
        /// This is required because of the inheritance in graphic layer.
        /// </summary>
        private const string ModelNameSpace = "SimpleGraphicsEditor.Data.Models";

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T">The type of the object which needs to be serialized.</typeparam>
        /// <param name="obj">Object to be serialized.</param>
        /// <returns>XML string generated from the serialization process</returns>
        public static string SerializeObject<T>(object obj)
        {
            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T), ModelNameSpace);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
                return xmlString;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Data);
                throw;
            }
        }

        /// <summary>
        /// Helper method to convert UTF8 Byte Array To String
        /// </summary>
        /// <param name="characters">UTF8 Byte Array</param>
        /// <returns>Converted string</returns>
        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return constructedString;
        }
    }
}
