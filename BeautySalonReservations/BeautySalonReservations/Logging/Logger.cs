using System;
using System.IO;
using System.Threading;

namespace BeautySalonReservations.Logging
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _lazy =
            new Lazy<Logger>(() => new Logger(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static Logger Instance { get { return _lazy.Value; } }

        private readonly string _logFilePath;

        private Logger()
        {
            _logFilePath = Path.Combine(AppContext.BaseDirectory, "app.log");
        }

    }
}
