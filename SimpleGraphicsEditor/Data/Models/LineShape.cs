namespace SimpleGraphicsEditor.Data.Models
{
    using System;

    /// <summary>
    /// Represents a Line shape
    /// </summary>
    [Serializable]
    public class LineShape : BaseShape
    {
        /// <summary>
        /// A variable to hold the X position at the end of the line
        /// </summary>
        private double secondXPostion;

        /// <summary>
        /// A variable to hold the X position at the end of the line
        /// </summary>
        private double secondYPostion;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineShape"/> class.
        /// </summary>
        public LineShape()
        {
        }

        /// <summary>
        /// Gets or sets SecondXPostion
        /// </summary>
        public double SecondXPostion
        {
            get { return this.secondXPostion; }
            set { this.SetProperty(ref this.secondXPostion, value); }
        }

        /// <summary>
        /// Gets or sets SecondXPostion
        /// </summary>
        public double SecondYPostion
        {
            get { return this.secondYPostion; }
            set { this.SetProperty(ref this.secondYPostion, value); }
        }

        /// <summary>
        /// A logic which can be overridden by sub classes if they wish for
        /// additional functionality when orpoerty is changed.
        /// </summary>
        internal override void PropertyUpdateChanges()
        {
            this.SecondXPostion = this.XPosition + this.ShapeWidth;
            this.SecondYPostion = this.YPosition - this.ShapeHeight;
        }
    }
}
