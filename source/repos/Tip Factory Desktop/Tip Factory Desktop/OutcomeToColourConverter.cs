using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Tip_Factory_Desktop
{
    public class OutcomeToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "DA")
                return Brushes.Green;
            else
                return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
