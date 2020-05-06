using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using REvernus.Models.EveDbModels;

namespace REvernus.Utilities.Converters
{
    public class TypeIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using var db = new eveContext();
            try
            {
                return db.InvTypes.FirstOrDefault(o => o.TypeId == System.Convert.ToInt64(value)); ;
            }
            finally
            {
                db.Dispose();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using var db = new eveContext();
            try
            {
                return db.InvTypes.FirstOrDefault(o => o.TypeName == System.Convert.ToString(value));
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
