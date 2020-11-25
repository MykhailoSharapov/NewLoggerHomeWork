using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewLoggerHomeWork
{
    class Logger
    {
        private Logger()
        {

        }
        private static Logger instance;
        private static StringBuilder LogMessages = new StringBuilder();
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
        public void Info(GlobalConstans.WarningLevels warningLevels, Exception ex)
        {
            string result = $"{nameof(warningLevels)}, Action failed by reason: {ex.StackTrace}";
            LogMessages.AppendLine(result);
            Console.WriteLine(result);
        }

        public void Info(GlobalConstans.WarningLevels warningLevels, string Message)
        {
            string result = $"{nameof(warningLevels)}, Message: {Message}";
            LogMessages.AppendLine(result);
            Console.WriteLine(result);
        }

        public void SaveLogFile()
        {
            File.WriteAllText(DateTime.Now.Ticks.ToString() + ".txt", LogMessages.ToString());
        }
    }
}
