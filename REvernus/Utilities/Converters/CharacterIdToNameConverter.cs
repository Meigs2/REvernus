using System;
using System.Globalization;
using System.Windows.Data;

namespace REvernus.Utilities.Converters
{
    internal class CharacterIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return App.AuthProvider.GetCharacterById(System.Convert.ToInt32(value))?.CharacterName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return App.AuthProvider.GetCharacterByName(System.Convert.ToString(value))?.CharacterDetails.CharacterId;
        }
    }
}