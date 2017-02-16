namespace SimpleGraphicsEditor.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Represents a converter which converts a string denominator to a <see cref="SolidColorBrush"/>
    /// which will be used to color graphics in the workspace area.
    /// </summary>
    public class StringValueToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string userColor = value as string;

            switch (userColor)
            {
                case "Red":
                    return new SolidColorBrush(Colors.Red);
                case "Green":
                    return new SolidColorBrush(Colors.Green);
                case "Blue":
                    return new SolidColorBrush(Colors.Blue);
                case "Yellow":
                    return new SolidColorBrush(Colors.Yellow);
                case "Orange":
                    return new SolidColorBrush(Colors.Orange);
                case "Magenta":
                    return new SolidColorBrush(Colors.Magenta);
                case "Pink":
                    return new SolidColorBrush(Colors.Pink);
                case "Black":
                    return new SolidColorBrush(Colors.Black);
                case "BlanchedAlmond":
                    return new SolidColorBrush(Colors.BlanchedAlmond);
                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// Converts back a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush shapeFillColor = value as SolidColorBrush;

            switch (shapeFillColor.Color.ToString())
            {
                case "Red":
                    return "Red";
                case "Green":
                    return "Green";
                case "Blue":
                    return "Blue";
                case "Yellow":
                    return "Yellow";
                case "Orange":
                    return "Orange";
                case "Magenta":
                    return "Magenta";
                case "Pink":
                    return "Pink";
                case "Black":
                    return "Black";
                default:
                    return "Black";
            }
        }
    }
}
