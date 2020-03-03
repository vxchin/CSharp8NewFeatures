using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpNewFeatures
{
    public static class DefaultInterfaceMembers
    {
        public static void Demo()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var logger = new ConsoleLogger();
            logger.Log(LogLevel.Error, "ERROR MESSAGE!");
            // Compile Error!
            //logger.LogInformation("INFORMATION MESSAGE!");

            ILogger consoleLogger = new ConsoleLogger();
            consoleLogger.LogWarning("WARNING MESSAGE!");

            ILogger traceLogger = new TraceLogger();
            traceLogger.LogInformation("INFORMATION MESSAGE!");
        }

        enum LogLevel
        {
            Information,
            Warning,
            Error
        }

        interface ILogger
        {
            void Log(LogLevel level, string message);

            private string Format(string format, string[] args) => String.Format(format, args);

            protected void Log(LogLevel level, string format, params string[] args) =>

                Log(level, Format(format, args));

            public void LogInformation(string message) => Log(LogLevel.Information, message);

            void LogWarning(string message) => Log(LogLevel.Warning, message);

            void LogError(string message) => Log(LogLevel.Error, message);
        }

        class ConsoleLogger : ILogger
        {
            public void Log(LogLevel level, string message) => Console.WriteLine($"{level}: {message}");
        }

        class TraceLogger : ILogger
        {
            public void Log(LogLevel level, string message)
            {
                switch (level)
                {
                    case LogLevel.Information:
                        Trace.TraceInformation(message);
                        break;

                    case LogLevel.Warning:
                        Trace.TraceWarning(message);
                        break;

                    case LogLevel.Error:
                        Trace.TraceError(message);
                        break;
                }
            }
        }
    }
}
