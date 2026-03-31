using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    // Adapter（轉接器模式）
    // 核心思想：將一個類別的介面轉換成客戶端期望的另一個介面，
    //   讓原本介面不相容的類別能夠協同工作。
    //   分為「物件轉接器（Object Adapter）」與「類別轉接器（Class Adapter）」兩種實作方式。
    // 使用情境：當你想複用現有類別，但其介面與目前系統要求不相容時。
    // 真實案例：
    //   1. 舊系統 Logger 適配新介面——如本範例，將 LegacyLogger 包裝成 IAppLogger。
    //   2. 第三方支付 SDK 適配——將不同支付服務（PayPal、Stripe）的 API 轉換成統一的 IPaymentGateway 介面。
    //   3. 資料格式轉換——將 XML 資料源的輸出轉換為 JSON 格式供新系統使用。
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
