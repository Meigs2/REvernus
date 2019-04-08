using System;
using System.Collections.Generic;
using System.Text;

namespace REvernus.Utilities
{
    public static class Startup
    {
        public static void PerformStartupActions()
        {
            Logging.SetupLogging();
        }
    }
}
