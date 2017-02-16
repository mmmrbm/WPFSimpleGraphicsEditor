namespace SimpleGraphicsEditor.Data.Models
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Represents a triangle shape
    /// </summary>
    [Serializable]
    public class TriangleShape : BaseShape
    {
        /// <summary>
        /// A variable to hold the collection of points
        /// </summary>
        private PointCollection points;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleShape"/> class.
        /// </summary>
        public TriangleShape()
        {
            this.Points = new PointCollection();
        }

        /// <summary>
        /// Gets or sets the Points which make up triangle via polygon
        /// </summary>
        public PointCollection Points
        {
            get { return this.points; }
            set { this.SetProperty(ref this.points, value); }
        }

        /// <summary>
        /// A logic which can be overridden by sub classes if they wish for
        /// additional functionality when orpoerty is changed.
        /// </summary>
        internal override void PropertyUpdateChanges()
        {
            this.Points.Clear();

            Point pointOne = new Point(this.XPosition, this.YPosition);
            Point pointTwo = new Point(this.XPosition + this.ShapeWidth, this.YPosition);
            Point pointThree = new Point(this.XPosition + (this.ShapeWidth / 2), this.YPosition - this.ShapeHeight);

            this.Points.Add(pointOne);
            this.Points.Add(pointTwo);
            this.Points.Add(pointThree);
            //this.Points.Add(pointFour);
        }
    }
}
