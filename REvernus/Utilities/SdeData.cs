using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;

namespace REvernus.Utilities
{
    public static class SdeData
    {
        public static string SdeDataBasePath => Path.Combine(Environment.CurrentDirectory, "Data", "eve.db");
        private static readonly SQLiteConnection SdeDatabaseConnection = new SQLiteConnection($"Data Source={SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True;FailIfMissing=True");

        public static ConcurrentDictionary<long, string> TypeIdToTypeNameDictionary { get; set; } = new ConcurrentDictionary<long, string>();

        public static string TypeIdToTypeName(long typeId)
        {
            return TypeIdToTypeNameDictionary[typeId];
        }

        /// <summary>
        /// Returns a DataTable containing the typeID and typeNames of all items currently on the market.
        /// </summary>
        /// <returns></returns>
        public static Task<DataTable> GetAllInventoryTypesAsync()
        {
            try
            {
                SdeDatabaseConnection.Open();
                var command = SdeDatabaseConnection.CreateCommand();
                command.CommandText = "SELECT * FROM 'invTypes' WHERE marketGroupID IS NOT null AND published IS true";

                var reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);

                SdeDatabaseConnection.Close();

                return Task.FromResult(dataTable);
            }
            catch (Exception e)
            {
                if (e is SQLiteException)
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(
                        "There was an error accessing the Static Data Export local database.\nHave you downloaded the Static Data Export under 'File'?", "Error", MessageBoxButton.OK);
                }
                Console.WriteLine(e);
                return Task.FromResult(new DataTable());
            }
        }

        public static async Task ImportSdeData()
        {
            TypeIdToTypeNameDictionary.Clear();

            var types = await GetAllInventoryTypesAsync();
            foreach (DataRow typesRow in types.Rows)
            {
                TypeIdToTypeNameDictionary.TryAdd((long) typesRow["typeID"], typesRow["typeName"].ToString());
            }
        }
    }
}
