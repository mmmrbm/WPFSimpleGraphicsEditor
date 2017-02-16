namespace SimpleGraphicsEditor.Data.Models
{
    using System;
    using System.Xml.Serialization;
    using Core;

    /// <summary>
    /// Represents the base structure for graphic shapes used in application
    /// </summary>
    [XmlRoot(Namespace = "DragCanvasSaveLoad.Model")]
    [XmlInclude(typeof(BaseShape))]
    [XmlInclude(typeof(BoxShape))]
    [XmlInclude(typeof(CircleShape))]
    [XmlInclude(typeof(LineShape))]
    [XmlInclude(typeof(TriangleShape))]
    [Serializable]
    public abstract class BaseShape : BindableBase
    {
        /// <summary>
        /// A variable to hold the Id assigned to the shape.
        /// </summary>
        private string shapeIdentifire;

        /// <summary>
        /// A variable to hold the current X Position of the shape
        /// </summary>
        private double xPosition;

        /// <summary>
        /// A variable to hold the current Y Position of the shape
        /// </summary>
        private double yPosition;

        /// <summary>
        /// A variable to hold the current Height of the shape
        /// </summary>
        private double shapeHeight;

        /// <summary>
        /// A variable to hold the current Width of the shape
        /// </summary>
        private double shapeWidth;

        /// <summary>
        /// A variable to hold the color of the shape
        /// </summary>
        private string shapeColor;

        /// <summary>
        /// Gets or sets Shape Identifire
        /// </summary>
        public string ShapeIdentifire
        {
            get
            {
                return this.shapeIdentifire;
            }

            set
            {
                this.SetProperty(ref this.shapeIdentifire, value);
            }
        }

        /// <summary>
        /// Gets or sets X Position of the shape
        /// </summary>
        public double XPosition
        {
            get
            {
                return this.xPosition;
            }

            set
            {
                this.SetProperty(ref this.xPosition, value);
                this.PropertyUpdateChanges();
            }
        }

        /// <summary>
        /// Gets or sets X Position of the shape
        /// </summary>
        public double YPosition
        {
            get
            {
                return this.yPosition;
            }

            set
            {
                this.SetProperty(ref this.yPosition, value);
                this.PropertyUpdateChanges();
            }
        }

        /// <summary>
        /// Gets or sets X Position of the shape
        /// </summary>
        public double ShapeWidth
        {
            get
            {
                return this.shapeWidth;
            }

            set
            {
                this.SetProperty(ref this.shapeWidth, value);
                this.PropertyUpdateChanges();
            }
        }

        /// <summary>
        /// Gets or sets X Position of the shape
        /// </summary>
        public double ShapeHeight
        {
            get
            {
                return this.shapeHeight;
            }

            set
            {
                this.SetProperty(ref this.shapeHeight, value);
                this.PropertyUpdateChanges();
            }
        }

        /// <summary>
        /// Gets or sets Color of the shape
        /// </summary>
        public string ShapeColor
        {
            get
            {
                return this.shapeColor;
            }

            set {
                this.SetProperty(ref this.shapeColor, value);
                this.PropertyUpdateChanges();
            }
        }

        /// <summary>
        /// A logic which can be overridden by sub classes if they wish for
        /// additional functionality when orpoerty is changed.
        /// </summary>
        internal virtual void PropertyUpdateChanges()
        {
        }
    }
}
