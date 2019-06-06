using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace REvernus.Utilities
{
    public static class SdeData
    {
        public static string SdeDataBasePath => Path.Combine(Environment.CurrentDirectory, "Data","eve.db");

        public static DataTable GetInventoryTypes()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={SdeDataBasePath};Version=3;New=True;Compress=true");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM 'invTypes'";

                var reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                dataTable.Rows.Cast<DataRow>().Where(r => r.ItemArray[11] is DBNull).ToList().ForEach(r => r.Delete());
                connection.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
