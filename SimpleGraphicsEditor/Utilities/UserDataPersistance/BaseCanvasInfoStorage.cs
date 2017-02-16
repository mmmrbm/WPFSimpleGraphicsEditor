namespace SimpleGraphicsEditor.Utilities.UserDataPersistance
{
    /// <summary>
    /// Represents an entity which will be used to store canvas information.
    /// </summary>
    public class BaseCanvasInfoStorage
    {
        /// <summary>
        /// Gets or sets Canvas Width
        /// </summary>
        public int CanvasWidth { get; set; }

        /// <summary>
        /// Gets or sets Canvas Height
        /// </summary>
        public int CanvasHeight { get; set; }

        /// <summary>
        /// Gets or sets Canvas Background color
        /// </summary>
        public string CanvasBackground { get; set; }
    }
}
