namespace Sorting.Algorithms.Core.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Logger
    {
        private readonly List<LogEntry> _logEntries = new List<LogEntry>();

        internal static Logger Default { get; } = new Logger();

        internal void Log(LogLevel logLevel, string message)
        {
            _logEntries.Add(new LogEntry(logLevel, message));
        }

        internal void Flush(LogLevel logLevel)
        {
            Console.Write(_logEntries.Where(entry => entry.LogLevel.HasFlag(logLevel)).Select(logEntry => logEntry.Entry).Join("\n"));
            _logEntries.Clear();
        }
    }
}