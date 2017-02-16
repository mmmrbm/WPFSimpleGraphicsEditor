namespace SimpleGraphicsEditor.TemplateSelectors
{
    using System.Windows;
    using System.Windows.Controls;
    using Data.Models;

    /// <summary>
    /// Represents a data template selector, which can be used to select
    /// template based on object type.
    /// </summary>
    public class ShapeTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets data template for <see cref="BoxShape"/>
        /// </summary>
        public DataTemplate BoxTemplate { get; set; }

        /// <summary>
        /// Gets or sets data template for <see cref="CircleShape"/>
        /// </summary>
        public DataTemplate CircleTemplate { get; set; }

        /// <summary>
        /// Gets or sets data template for <see cref="LineShape"/>
        /// </summary>
        public DataTemplate LineTemplate { get; set; }

        /// <summary>
        /// Gets or sets data template for <see cref="TriangleShape"/>
        /// </summary>
        public DataTemplate TriangleTemplate { get; set; }

        /// <summary>
        /// Returns a System.Windows.DataTemplate based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>Returns a System.Windows.DataTemplate or null. The default value is null.</returns>
        public override DataTemplate SelectTemplate(
            object item,
            DependencyObject container)
        {
            if (item != null)
            {
                if (item is BoxShape)
                {
                    return this.BoxTemplate;
                }

                if (item is CircleShape)
                {
                    return this.CircleTemplate;
                }

                if (item is LineShape)
                {
                    return this.LineTemplate;
                }

                if (item is TriangleShape)
                {
                    return this.TriangleTemplate;
                }

                return base.SelectTemplate(item, container);
            }

            return base.SelectTemplate(item, container);
        }
    }
}
