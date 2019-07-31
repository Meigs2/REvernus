using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace REvernus.Utilities
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
