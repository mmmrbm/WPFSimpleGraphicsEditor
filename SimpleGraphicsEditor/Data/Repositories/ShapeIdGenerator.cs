namespace SimpleGraphicsEditor.Data.Repositories
{
    /// <summary>
    /// Represents an ID generator for Shape Classes.
    /// Mimics functionality of a sequence in a database.
    /// </summary>
    public static class ShapeIdGenerator
    {
        public static string GenerateUniqued()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
