using System;
using System.IO;

namespace REvernus.Utilities
{
    public static class Paths
    {
        // Directories
        public static string CurrentDirectory => Environment.CurrentDirectory;

        public static string DataFolderPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "REvernus", "Data");

        public static string DataBaseFolderPath => Path.Combine(DataFolderPath, "db");
        public static string SerializedDataFolder => Path.Combine(DataFolderPath, "Serialized Data");

        public static string EveDocumentsFolderPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EVE");

        public static string EveFleetLogsFolderPath => Path.Combine(EveDocumentsFolderPath, "logs", "Fleetlogs");
        public static string EveMarketLogsFolderPath => Path.Combine(EveDocumentsFolderPath, "logs", "Marketlogs");
        public static string EveGameLogsFolderPath => Path.Combine(EveDocumentsFolderPath, "logs", "Gamelogs");
        public static string EveChatlogsLogsFolderPath => Path.Combine(EveDocumentsFolderPath, "logs", "Chatlogs");

        // DB Paths
        public static string SdeDataBasePath => Path.Combine(DataBaseFolderPath, "eve.db");
        public static string CompressedSdeDataBasePath => Path.Combine(DataBaseFolderPath, "eve.db.bz2");
        public static string UserDataBasePath => Path.Combine(DataBaseFolderPath, "user.db");
    }
}