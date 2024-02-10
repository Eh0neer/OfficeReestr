using System;
using Serilog;

namespace OfficeReestr.Utilities
{
    public static class Logger
    {
        private static readonly ILogger Log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        public static void LogError(Exception exception, string message)
        {
            Log.Error(exception, message);
        }
    }
}

