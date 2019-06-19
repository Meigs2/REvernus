using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using REvernus.Core;

namespace REvernus.Utilities
{
    public static class StartupAndExit
    {
        public static async Task PerformStartupActions()
        {
            Logging.SetupLogging();

            await CharacterManager.DeserializeCharacters();

            await SdeData.ImportSdeData();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            CharacterManager.SerializeCharacters();
        }
    }
}
