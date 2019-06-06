using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;

namespace REvernus.Utilities
{
    public static class SdeData
    {
        public static string SdeDataBasePath => Path.Combine(Environment.CurrentDirectory, "Data","eve.db");
        private static readonly SQLiteConnection SdeDatabaseConnection = new SQLiteConnection($"Data Source={SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True;FailIfMissing=True");

        public static DataTable GetInventoryTypes()
        {
            try
            {
                SdeDatabaseConnection.Open();
                var command = SdeDatabaseConnection.CreateCommand();
                command.CommandText = "SELECT * FROM 'invTypes'";

                var reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);

                dataTable.Rows.Cast<DataRow>().Where(r => r.ItemArray[11] is DBNull).ToList().ForEach(r => r.Delete());

                SdeDatabaseConnection.Close();

                return dataTable;
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(SQLiteException))
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(
                        "There was an error accessing the Static Data Export local database.\nHave you downloaded the Static Data Export under File?","Error", MessageBoxButton.OK);
                }
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
