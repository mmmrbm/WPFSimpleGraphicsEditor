namespace SimpleGraphicsEditor.Data.Factories
{
    using Repositories;
    using SimpleGraphicsEditor.Data.Models;

    /// <summary>
    /// Represents an object which expose a factory method to get entities of type <see cref="BaseShape"/>
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// A reference to hold the instance of <see cref="EventHub"/>
        /// </summary>
        private static volatile ShapeFactory instance;

        /// <summary>
        /// A locking object used to handle singleton creation on multi-threaded environments.
        /// </summary>
        private static object syncRoot = new object();

        /// <summary>
        /// A variable to hold a reference to <see cref="ShapeRepository"/>
        /// </summary>
        private ShapeRepository shapeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeFactory"/> class.
        /// </summary>
        private ShapeFactory()
        {
            this.shapeRepository = new ShapeRepository();
        }

        /// <summary>
        /// Exposes the single instance of <see cref="ShapeFactory"/>
        /// </summary>
        /// <returns>The single instance of <see cref="ShapeFactory"/></returns>
        public static ShapeFactory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ShapeFactory();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Gets an object which represents of type <see cref="BaseShape"/>.
        /// </summary>
        /// <param name="shapeKeyDenominator">The key of shape required by client.</param>
        /// <returns>A <see cref="BaseShape"/> object.</returns>
        public BaseShape GetShape(
            string shapeKeyDenominator)
        {
            switch (shapeKeyDenominator)
            {
                case "Square":
                    return this.shapeRepository.GetSquare();
                case "Rectangle":
                    return this.shapeRepository.GetRectangle();
                case "Circle":
                    return this.shapeRepository.GetCircle();
                case "Ellipse":
                    return this.shapeRepository.GetEllipse();
                case "Triangle":
                    return this.shapeRepository.GetTriangle();
                case "Line":
                    return this.shapeRepository.GetLine(); ;
                default:
                    return null;
            }
        }
    }
}
