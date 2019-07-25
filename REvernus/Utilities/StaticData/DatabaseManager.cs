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
using System.Windows.Input;

namespace REvernus.Utilities.StaticData
{
    public static class DatabaseManager
    {
        private static readonly SQLiteConnection ReadOnlyEveDbConnection = new SQLiteConnection($"Data Source={Utilities.Paths.SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True;FailIfMissing=True");
        private static readonly SQLiteConnection UserDataDbConnection = new SQLiteConnection($"Data Source={Utilities.Paths.SdeDataBasePath};Version=3;");

        public static DataTable QueryEveDb(string commandText)
        {
            try
            {
                ReadOnlyEveDbConnection.Open();
                var command = ReadOnlyEveDbConnection.CreateCommand();
                command.CommandText = commandText;

                var reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);

                ReadOnlyEveDbConnection.Close();

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
                return null;
            }
        }

        public static async Task Initialize()
        {
            if (!File.Exists(Paths.SdeDataBasePath))
            {
                var boxResult = MessageBox.Show("The EvE Static Data Export is required for REvernus to function properly." +
                                                "Would you like to download it now? If you decide to not download it now, REvernus will Exit.", "Warning", MessageBoxButton.YesNo);

                if (boxResult == MessageBoxResult.No) Application.Current.Shutdown(-2);

                await Task.Run(new SdeDownloader().DownloadLatestSde);
            }

            if (!File.Exists(Paths.UserDataBasePath))
            {
                Directory.CreateDirectory(Paths.DataBaseFolderPath);
                CreateUserDataTable();
            }

            // todo: and and verify user.db settings table
        }

        public static Task<DataTable> QueryEveDbAsync(string commandText)
        {
            return Task.FromResult(QueryEveDb(commandText));
        }

        private static void CreateUserDataTable()
        {
            SQLiteConnection.CreateFile(Paths.UserDataBasePath);

            UserDataDbConnection.Open();

            // Create settings table
            using (var sqLiteCommand = new SQLiteCommand(@"CREATE TABLE settings (settingName TEXT, settingValue BLOB)", UserDataDbConnection))
            {
                sqLiteCommand.ExecuteNonQuery();
            }

            UserDataDbConnection.Close();
        }

        private static T ByteToObject<T>(byte[] param)
        {
            using MemoryStream ms = new MemoryStream(param);
            IFormatter br = new BinaryFormatter();
            return (T)br.Deserialize(ms);
        }
    }
}
