using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace REvernus.Utilities
{
    public class Settings
    {
        private static Settings _currentInstance;
        public static Settings CurrentInstance
        {
            get { return _currentInstance ??= new Settings(); }
        }

        public static void SerializeSettings()
        {
            Serializer.SerializeData(_currentInstance, Paths.SettingsDataFilePath);
        }

        public static void DeserializeSettings()
        {
            Serializer.DeserializeData<Settings>(Paths.SettingsDataFilePath);
        }
    }
}
