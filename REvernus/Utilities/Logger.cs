using System;
using System.Reflection;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository;

namespace REvernus.Utilities
{
    public class Logger
    {
        [AttributeUsage(AttributeTargets.Assembly)]
        public class LogConfigurator : ConfiguratorAttribute
        {
            public LogConfigurator()
                : base(0)
            {

            }

            public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
            {
                var hierarchy = (Hierarchy)targetRepository;
                var patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
                patternLayout.ActivateOptions();

                var roller = new RollingFileAppender();
                roller.AppendToFile = true;
                roller.File = "REvernus.log";
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = "1MB";
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.StaticLogFileName = true;
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                hierarchy.Root.Level = Level.Info;
                hierarchy.Configured = true;
            }
        }
    }
}
