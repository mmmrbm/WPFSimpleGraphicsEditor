namespace SimpleGraphicsEditor.Data.Repositories
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Represents a repository which manage entities of type <see cref="BaseShape"/>
    /// </summary>
    public class ShapeRepository
    {
        /// <summary>
        /// A collection which mimics database functionality
        /// </summary>
        private Dictionary<string, BaseShape> shapeDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRepository"/> class.
        /// </summary>
        public ShapeRepository()
        {
            this.shapeDatabase = new Dictionary<string, BaseShape>();
            this.Seed();
        }

        /// <summary>
        /// Gets all shapes in the repository.
        /// </summary>
        /// <returns>Collection of all shapes in the repository.</returns>
        public ICollection<BaseShape> GetAllShapes()
        {
            List<BaseShape> allShapeDataHolder = new List<BaseShape>();
            foreach (var shapeData in this.shapeDatabase)
            {
                allShapeDataHolder.Add(shapeData.Value);
            }

            return allShapeDataHolder;
        }

        /// <summary>
        /// Gets a single shape from database structure associated with the Shape Key Denominator
        /// </summary>
        /// <param name="shapeKeyDenominator">The key of the shape needs to be fetched.</param>
        /// <returns>The shape for the key.</returns>
        public BaseShape GetShape(
            string shapeKeyDenominator)
        {
            return this.shapeDatabase[shapeKeyDenominator];
        }

        /// <summary>
        /// Gets an object which represents a Square.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetSquare()
        {
            BoxShape defaultSquareShape = new BoxShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 50,
                ShapeWidth = 50,
                ShapeColor = "Black"
            };

            return defaultSquareShape;
        }

        /// <summary>
        /// Gets an object which represents a Rectangle.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetRectangle()
        {
            BoxShape defaultRectangleShape = new BoxShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            return defaultRectangleShape;
        }

        /// <summary>
        /// Gets an object which represents a Circle.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetCircle()
        {
            CircleShape defaultCircleShape = new CircleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 50,
                ShapeColor = "Black"
            };

            return defaultCircleShape;
        }

        /// <summary>
        /// Gets an object which represents a Ellipse.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetEllipse()
        {
            CircleShape defaultEllipseShape = new CircleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            return defaultEllipseShape;
        }

        /// <summary>
        /// Gets an object which represents a Triangle.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetTriangle()
        {
            TriangleShape defaultTriangleShape = new TriangleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            return defaultTriangleShape;
        }

        /// <summary>
        /// Gets an object which represents a Line.
        /// </summary>
        /// <returns>An object which represents a square.</returns>
        public BaseShape GetLine()
        {
            LineShape defaultLineShape = new LineShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 0,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            return defaultLineShape;
        }

        /// <summary>
        /// Mimics data retrieved from a resource
        /// </summary>
        private void Seed()
        {
            BoxShape defaultSquareShape = new BoxShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 50,
                ShapeWidth = 50,
                ShapeColor = "Black"
            };

            BoxShape defaultRectangleShape = new BoxShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            CircleShape defaultCircleShape = new CircleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 50,
                ShapeColor = "Black"
            };

            CircleShape defaultEllipseShape = new CircleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            TriangleShape defaultTriangleShape = new TriangleShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 50,
                YPosition = 50,
                ShapeHeight = 50,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            LineShape defaultLineShape = new LineShape
            {
                ShapeIdentifire = ShapeIdGenerator.GenerateUniqued(),
                XPosition = 0,
                YPosition = 0,
                ShapeHeight = 0,
                ShapeWidth = 100,
                ShapeColor = "Black"
            };

            this.shapeDatabase.Add("Square", defaultSquareShape);
            this.shapeDatabase.Add("Rectangle", defaultRectangleShape);
            this.shapeDatabase.Add("Circle", defaultCircleShape);
            this.shapeDatabase.Add("Ellipse", defaultEllipseShape);
            this.shapeDatabase.Add("Triangle", defaultTriangleShape);
            this.shapeDatabase.Add("Line", defaultLineShape);
        }
    }
}
