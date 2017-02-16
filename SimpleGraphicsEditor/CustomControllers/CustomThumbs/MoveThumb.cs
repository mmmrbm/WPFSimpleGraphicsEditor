namespace SimpleGraphicsEditor.CustomControllers.CustomThumbs
{
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using EventManagment;

    /// <summary>
    /// Represents a custom <see cref="Thumb"/> which will be used to drag graphics
    /// </summary>
    public class MoveThumb : Thumb
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveThumb"/> class.
        /// </summary>
        public MoveThumb()
        {
            this.DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        /// <summary>
        /// Event handler logic for event DragDelta
        /// </summary>
        /// <param name="sender">Source of the event. This will be the graphic container.</param>
        /// <param name="e">Event argument object.</param>
        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control designerItem = this.DataContext as Control;
            double finalX = 0.0;
            double finalY = 0.0;

            if (designerItem != null)
            {
                double left = Canvas.GetLeft(designerItem);
                double top = Canvas.GetTop(designerItem);

                Canvas.SetLeft(designerItem, left + e.HorizontalChange);
                Canvas.SetTop(designerItem, top + e.VerticalChange);

                finalX = left + e.HorizontalChange;
                finalY = top + e.VerticalChange;
            }

            TextBlock descText = (TextBlock)designerItem.FindName("ShapeId");
            EventHub hub = EventHub.GetInstance();
            hub.RaiseDragEventCompleted(descText.Text, finalX, finalY);
        }
    }
}
