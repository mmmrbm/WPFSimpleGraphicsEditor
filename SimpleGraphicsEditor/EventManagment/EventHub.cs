namespace SimpleGraphicsEditor.EventManagment
{
    using System;

    /// <summary>
    /// Represents a central location to define all custom events.
    /// </summary>
    public sealed class EventHub
    {
        /// <summary>
        /// A reference to hold the instance of <see cref="EventHub"/>
        /// </summary>
        private static volatile EventHub instance;

        /// <summary>
        /// A locking object used to handle singleton creation on multi-threaded environments.
        /// </summary>
        private static object syncRoot = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHub"/> class.
        /// Follows singleton pattern since single hub should be used
        /// </summary>
        private EventHub()
        {
        }

        /// <summary>
        /// Event which will be fired when a graphic gets resized.
        /// </summary>
        public event Action<string, double[]> ResizeEventCompleted = (str, array) => { };

        /// <summary>
        /// Event which will be fired when a graphic gets dragged.
        /// </summary>
        public event Action<string, double[]> DragEventCompleted = (str, array) => { };

        /// <summary>
        /// Exposes the single instance of <see cref="EventHub"/>
        /// </summary>
        /// <returns>The single instance of <see cref="EventHub"/></returns>
        public static EventHub GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new EventHub();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Raises the ResizeEventCompleted completed event, so that subscribers can act accoridingly.
        /// </summary>
        /// <param name="shapeId">Id of the shape which has been resized.</param>
        /// <param name="finalHeight">Final height after resize.</param>
        /// <param name="finalWidth">Final width after resize.</param>
        public void RaiseResizeEventCompleted(string shapeId, double finalHeight, double finalWidth)
        {
            double[] heightWidthInfoCollection = { finalHeight, finalWidth };
            this.ResizeEventCompleted(shapeId, heightWidthInfoCollection);
        }

        /// <summary>
        /// Raises the DragEventCompleted completed event, so that subscribers can act accoridingly.
        /// </summary>
        /// <param name="shapeId">Id of the shape which has been dragged.</param>
        /// <param name="finalX">Final X Position after dragged.</param>
        /// <param name="finalY">Final Y Position after dragged.</param>
        public void RaiseDragEventCompleted(string shapeId, double finalX, double finalY)
        {
            double[] pointInfoCollection = { finalX, finalY };
            this.DragEventCompleted(shapeId, pointInfoCollection);
        }
    }
}
