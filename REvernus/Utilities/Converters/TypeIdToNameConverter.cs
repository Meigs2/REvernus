using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace REvernus.Utilities.Converters
{
    public class TypeIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using var connection = new SQLiteConnection(DatabaseManager.ReadOnlyEveDbConnection);
            connection.Open();

            using var sqLiteCommand = new SQLiteCommand("SELECT typeName FROM invTypes WHERE typeId is @typeId", connection);
            sqLiteCommand.Parameters.AddWithValue("@typeId", System.Convert.ToInt64(value));
            try
            {
                using var reader = sqLiteCommand.ExecuteReader();
                while (reader.Read())
                {
                    return System.Convert.ToString(reader[0]);
                }
                connection.Close();
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using var connection = new SQLiteConnection(DatabaseManager.ReadOnlyEveDbConnection);
            connection.Open();

            using var sqLiteCommand = new SQLiteCommand("SELECT typeId FROM invTypes WHERE typeName is @typeName", connection);
            sqLiteCommand.Parameters.AddWithValue("@typeName", System.Convert.ToString(value));
            try
            {
                using var reader = sqLiteCommand.ExecuteReader();
                while (reader.Read())
                {
                    return System.Convert.ToInt64(reader[0]);
                }
                connection.Close();
            }
            finally
            {
                connection.Close();
            }

            return null;
        }
    }
}
