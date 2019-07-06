using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using REvernus.Core;
using REvernus.Utilities.StaticData;

namespace REvernus.Utilities
{
    public static class StartupAndExit
    {
        public static async Task PerformStartupActions()
        {
            Logging.SetupLogging();

            await CharacterManager.DeserializeCharacters();

            await EveItems.ImportSdeData();

            await Structures.LoadStructureDictionary();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            CharacterManager.SerializeCharacters();
        }
    }
}
