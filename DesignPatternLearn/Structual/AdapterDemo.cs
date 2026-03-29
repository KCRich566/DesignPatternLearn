using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    internal class AdapterDemo : IPatternDemo
    {
        public string Name => "Adapter";
        public void Run()
        {
            Console.WriteLine("=== Adapter Pattern - Practical Logger Integration ===");

            var legacy = new LegacyLogger();
            legacy.LogMessage("This is a legacy log message", 1);
            legacy.LogMessage("This is a legacy error message", 3);

            IAppLogger appLogger = new LoggerObjectAdapter(legacy);
            ApplicationComponentThatLogs(appLogger);

            IAppLogger classAdapter = new LegacyClassLoggerAdapter();
            ApplicationComponentThatLogs(classAdapter);

        }

        private void ApplicationComponentThatLogs(IAppLogger logger)
        {
            logger.LogInfo("User logged in");
            logger.LogError("Unable to load profile");
        }


        internal interface IAppLogger
        {
            void LogInfo(string message);
            void LogError(string message);
        }

        internal class  LegacyLogger
        {
            // virtual 表示這個方法可以被子類別覆寫，允許子類別提供自己的實現。
            public virtual void LogMessage(string message, int level)
            {
                var levelName = level == 1 ? "INFO" : level == 2 ? "WARN" : "ERROR";
                Console.WriteLine($"[LegacyLogger] {levelName}: {message}");
            }
        }

        // 使用物件組合的方式實現Adapter，將LegacyLogger作為成員變量，並實現IAppLogger接口
        internal class LoggerObjectAdapter : IAppLogger
        {
            private readonly LegacyLogger _legacyLogger;
            public LoggerObjectAdapter(LegacyLogger legacyLogger)
            {
                if (legacyLogger == null) throw new ArgumentNullException(nameof(legacyLogger));
                _legacyLogger = legacyLogger;
            }

            public void LogInfo(string message)
            {
                _legacyLogger.LogMessage(message, 1);
            }
            public void LogError(string message)
            {
                _legacyLogger.LogMessage(message, 3);
            }
        }

        // 使用繼承的方式實現Adapter，直接繼承LegacyLogger並實現IAppLogger接口
        internal class LegacyClassLoggerAdapter : LegacyLogger, IAppLogger
        {
            public void LogInfo(string message)
            {
                base.LogMessage(message, 1);
            }

            public void LogError(string message)
            {
                base.LogMessage(message, 3);
            }
        }
    }
}
