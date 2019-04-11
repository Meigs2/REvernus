using Microsoft.Extensions.Logging;

namespace EVEStandard
{
    internal static class LibraryLogging
    {
        internal static ILoggerFactory LoggerFactory { get; set; } = new LoggerFactory();
        internal static ILogger CreateLogger<T>() =>
          LoggerFactory.CreateLogger<T>();
    }
}
