using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace REvernus.Utilities
{
    public static class Paths
    {
        public static string CurrentDirectory => Environment.CurrentDirectory;
        public static string DataFolderPath => Path.Combine(CurrentDirectory, "Data");

        // DB Paths
        public static string DataBaseFolderPath => Path.Combine(DataFolderPath, "db");
        public static string SdeDataBasePath => Path.Combine(DataBaseFolderPath, "eve.db");
        public static string CompressedSdeDataBasePath => Path.Combine(DataBaseFolderPath, "eve.db.bz2");


        public static string CharacterDataFilePath => Path.Combine(DataFolderPath, "Characters.bin");
        public static string SettingsDataFilePath => Path.Combine(DataFolderPath, "Settings.bin");
    }
}
