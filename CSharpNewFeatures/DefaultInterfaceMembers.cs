using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class DefaultInterfaceMembers
    {
        public static void Demo()
        {
            var lc = LoggerFactory.GetLogger(LoggerType.Console);
            lc.Log("Hello");

            var ld = LoggerFactory.GetLogger(LoggerType.Database);
            ld.Log("Hello");
        }

        interface ILogger
        {
            void Log(string msg);
        }

        interface IConsoleLogger : ILogger
        {
            void ILogger.Log(string msg) => Console.WriteLine(msg);
        }

        class ConsoleLogger : IConsoleLogger { }

        interface IDatabaseLogger : ILogger
        {
            void ILogger.Log(string msg) => Console.WriteLine($"'{msg}' inserted in DB.");
        }

        class DatabaseLogger : IDatabaseLogger { }

        // ... Several other Loggers ...

        enum LoggerType { Console, Database, /* ... */ }

        static class LoggerFactory
        {
            public static ILogger GetLogger(LoggerType ltype) => ltype switch
            {
                LoggerType.Console => new ConsoleLogger(),
                LoggerType.Database => new DatabaseLogger(),
                _ => throw new InvalidOperationException("Logger doesn't exist...")
            };
        }
    }
}
