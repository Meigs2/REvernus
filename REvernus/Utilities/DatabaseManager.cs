using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using REvernus.Utilities.StaticData;

namespace REvernus.Utilities
{
    public static class DatabaseManager
    {
        public static readonly SQLiteConnection ReadOnlyEveDbConnection = new SQLiteConnection($"Data Source={Paths.SdeDataBasePath};Version=3;New=True;Compress=true;Read Only=True");
        public static readonly SQLiteConnection UserDataDbConnection = new SQLiteConnection($"Data Source={Paths.UserDataBasePath};Version=3;");

        public static DataTable QueryEveDb(string commandText, SQLiteConnection connection)
        {
            using (connection)
            {
                try
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;
        }


        public static async Task Initialize()
        {
            if (!File.Exists(Paths.UserDataBasePath))
            {
                CreateUserDataTable();
            }
            InitializeUserDataTable();

            if (!File.Exists(Paths.SdeDataBasePath))
            {
                var boxResult = MessageBox.Show("The EvE Static Data Export is required for REvernus to function properly." +
                                                "Would you like to download it now? If you decide to not download it now, REvernus will Exit.", "Warning", MessageBoxButton.YesNo);

                if (boxResult == MessageBoxResult.No) Application.Current.Shutdown(-2);

                Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                var sdeDownloader = new SdeDownloader();
                await sdeDownloader.DownloadLatestSde();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
        }

        private static void CreateUserDataTable()
        {
            try
            {
                if (!Directory.Exists(Paths.DataBaseFolderPath))
                {
                    Directory.CreateDirectory(Paths.DataBaseFolderPath);
                }
                SQLiteConnection.CreateFile(Paths.UserDataBasePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static readonly string RefreshTokenTableName = "refreshTokens";

        private static void InitializeUserDataTable()
        {
            try
            {
                var userDbConnection = new SQLiteConnection(UserDataDbConnection);
                userDbConnection.Open();

                // Verify/Initialize refreshTokens table
                if (!TableExists("refreshTokens", userDbConnection))
                {
                    using var sqLiteCommand = new SQLiteCommand(@"CREATE TABLE refreshTokens (refreshToken TEXT)", userDbConnection);
                    sqLiteCommand.ExecuteNonQuery();
                }

                userDbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool TableExists(string tableName, SQLiteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
            return (cmd.ExecuteScalar() != null);
        }

    }
}
