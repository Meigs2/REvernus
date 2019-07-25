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
        public static void PerformStartupActions()
        {
            try
            {
                Logging.SetupLogging();

                Task.Run(DatabaseManager.Initialize).GetAwaiter().GetResult();

                Task.Run(CharacterManager.Initialize).GetAwaiter().GetResult();

                Task.Run(EveItems.Initialize).GetAwaiter().GetResult();

                Task.Run(Structures.Initialize).GetAwaiter().GetResult();
                
                Task.Run(Settings.Initialize).GetAwaiter().GetResult();

                AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            CharacterManager.SerializeCharacters();
        }
    }
}
