namespace SimpleGraphicsEditor.CustomControllers.CustomThumbs
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using EventManagment;

    /// <summary>
    /// Represents a custom <see cref=""/> Thumb control which will be used to resize graphics.
    /// </summary>
    public class ResizeThumb : Thumb
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeThumb"/> class.
        /// </summary>
        public ResizeThumb()
        {
            this.DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        /// <summary>
        /// Event handler logic for event DragDelta
        /// </summary>
        /// <param name="sender">Source of the event. This will be the graphic container.</param>
        /// <param name="e">Event argument object.</param>
        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control designerItem = this.DataContext as Control;

            if (designerItem != null)
            {
                double deltaVertical, deltaHorizontal;

                switch (this.VerticalAlignment)
                {
                    case System.Windows.VerticalAlignment.Bottom:
                        deltaVertical = Math.Min(-e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                        designerItem.Height = designerItem.ActualHeight - deltaVertical;
                        break;
                    case System.Windows.VerticalAlignment.Top:
                        deltaVertical = Math.Min(e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                        Canvas.SetTop(designerItem, Canvas.GetTop(designerItem) + deltaVertical);
                        designerItem.Height = designerItem.ActualHeight - deltaVertical;
                        break;
                    default:
                        break;
                }

                switch (this.HorizontalAlignment)
                {
                    case System.Windows.HorizontalAlignment.Left:
                        deltaHorizontal = Math.Min(e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                        Canvas.SetLeft(designerItem, Canvas.GetLeft(designerItem) + deltaHorizontal);
                        designerItem.Width = designerItem.ActualWidth - deltaHorizontal;
                        break;
                    case System.Windows.HorizontalAlignment.Right:
                        deltaHorizontal = Math.Min(-e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                        designerItem.Width = designerItem.ActualWidth - deltaHorizontal;
                        break;
                    default:
                        break;
                }
            }

            TextBlock descText = (TextBlock)designerItem.FindName("ShapeId");
            EventHub hub = EventHub.GetInstance();
            hub.RaiseResizeEventCompleted(descText.Text, designerItem.Height, designerItem.Width);

            e.Handled = true;
        }
    }
}
