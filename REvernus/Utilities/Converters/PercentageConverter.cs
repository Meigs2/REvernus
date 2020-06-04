using System;
using System.Globalization;
using System.Windows.Data;

namespace REvernus.Utilities.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null) return null;
                var fraction = decimal.Parse(value.ToString());
                return fraction.ToString("P2");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null) return null;
                var valueWithoutPercentage = value.ToString().TrimEnd(' ', '%');
                return decimal.Parse(valueWithoutPercentage) / 100;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}