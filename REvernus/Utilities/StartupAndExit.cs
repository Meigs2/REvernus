using REvernus.Core;
using REvernus.Utilities.StaticData;
using System;
using System.Threading.Tasks;

namespace REvernus.Utilities
{
    public class StartupAndExit
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task PerformStartupActions()
        {
            Logging.SetupLogging();

            await DatabaseManager.Initialize();

            await CharacterManager.Initialize();

            EveItems.Initialize();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            CharacterManager.SaveCharactersToDb();
        }
    }
}
