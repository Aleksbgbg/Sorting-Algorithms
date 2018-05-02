namespace Sorting.Algorithms.Core.Logging
{
    internal class LogEntry
    {
        internal LogEntry(LogLevel logLevel, string entry)
        {
            LogLevel = logLevel;
            Entry = entry;
        }

        internal LogLevel LogLevel { get; }

        internal string Entry { get; }
    }
}