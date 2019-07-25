using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Events;
using REvernus.Core;
using REvernus.Utilities.StaticData;

namespace REvernus.Utilities
{
    public class StartupAndExit
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task PerformStartupActions()
        {
            try
            {
                Logging.SetupLogging();

                await DatabaseManager.Initialize();

                await CharacterManager.Initialize();

                EveItems.Initialize();

                //Settings.Initialize();

                AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
            }
            catch (Exception e)
            {
                Log.Fatal(e);
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            CharacterManager.SerializeCharacters();
        }
    }
}
