namespace Sorting.Algorithms.Core.Logging
{
    using System;
    using System.Text;

    internal class Logger
    {
        private readonly StringBuilder _infoLog = new StringBuilder();

        private readonly StringBuilder _debugLog = new StringBuilder();

        internal static Logger Default { get; } = new Logger();

        internal void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Info:
                    _infoLog.AppendLine(message);
                    _debugLog.AppendLine(message);
                    break;

                case LogLevel.Debug:
                    _debugLog.AppendLine(message);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, "LogLevel must be Debug or Info.");
            }
        }

        internal void Flush(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Info:
                    Console.Write(_infoLog);
                    _infoLog.Clear();
                    break;

                case LogLevel.Debug:
                    Console.Write(_debugLog);
                    _debugLog.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, "LogLevel must be Debug or Info.");
            }
        }
    }
}