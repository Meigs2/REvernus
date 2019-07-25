using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Media;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using EVEStandard.Models;

namespace REvernus.Utilities.StaticData
{
    public static class DatabaseManager
    {
        public static readonly SQLiteConnection ReadOnlyEveDbConnection = new SQLiteConnection($"Data Source={Paths.SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True;FailIfMissing=True");
        public static readonly SQLiteConnection UserDataDbConnection = new SQLiteConnection($"Data Source={Paths.UserDataBasePath};Version=3;");

        public static DataTable QueryEveDb(string commandText, SQLiteConnection connection)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = commandText;

                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    connection.Close();
                    return dataTable;
                }
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
                return null;
            }
        }

        public static async Task Initialize()
        {

            if (!File.Exists(Paths.UserDataBasePath))
            {
                CreateUserDataTable();
            }

            if (!File.Exists(Paths.SdeDataBasePath))
            {
                var boxResult = MessageBox.Show("The EvE Static Data Export is required for REvernus to function properly." +
                                                "Would you like to download it now? If you decide to not download it now, REvernus will Exit.", "Warning", MessageBoxButton.YesNo);

                if (boxResult == MessageBoxResult.No) Application.Current.Shutdown(-2);

                var sdeDownloader = new SdeDownloader();
                await sdeDownloader.DownloadLatestSde();
            }

            // todo: and and verify user.db settings table
        }

        private static void CreateUserDataTable()
        {
            try
            {
                SQLiteConnection.CreateFile(Paths.UserDataBasePath);
                var connection = new SQLiteConnection(UserDataDbConnection);
                connection.Open();
                // Create settings table
                using var sqLiteCommand = new SQLiteCommand(@"CREATE TABLE settings (settingName INT, settingValue INT)", connection);
                sqLiteCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static T ByteToObject<T>(byte[] param)
        {
            using MemoryStream ms = new MemoryStream(param);
            IFormatter br = new BinaryFormatter();
            return (T)br.Deserialize(ms);
        }
    }
}
