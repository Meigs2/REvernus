using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace REvernus.Utilities.Converters
{
    class CharacterIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var character = App.CharacterManager.CharacterList.FirstOrDefault(c =>
                c.CharacterDetails.CharacterId == System.Convert.ToInt32(value));

            return character?.CharacterName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var character = App.CharacterManager.CharacterList.FirstOrDefault(c =>
                c.CharacterName == System.Convert.ToString(value));

            return character?.CharacterName;
        }
    }
}
