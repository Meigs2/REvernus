using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;

namespace REvernus.Utilities.StaticData
{
    public static class DatabaseManager
    {
        public static string SdeDataBasePath => Path.Combine(Environment.CurrentDirectory, "Data", "eve.db");
        private static readonly SQLiteConnection ReadOnlyDbConnection = new SQLiteConnection($"Data Source={SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True;FailIfMissing=True");

        public static DataTable QueryEveDb(string commandText)
        {
            try
            {
                ReadOnlyDbConnection.Open();
                var command = ReadOnlyDbConnection.CreateCommand();
                command.CommandText = commandText;

                var reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);

                ReadOnlyDbConnection.Close();

                return dataTable;
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
                return new DataTable();
            }
        }

        public static Task<DataTable> QueryEveDbAsync(string commandText)
        {
            return Task.FromResult(QueryEveDb(commandText));
        }
    }
}
