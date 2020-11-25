using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewLoggerHomeWork
{
    public class Logger
    {
        private Logger()
        {

        }
        private static Logger instance;
        private StringBuilder LogMessages = new StringBuilder();
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
        public void Log(LogLevel warningLevels, Exception ex)
        {
            string result = $"{warningLevels}, Action failed by reason: {ex.StackTrace}";
            LogMessages.AppendLine(result);
            Console.WriteLine(result);
        }

        public void Log(LogLevel warningLevels, string Message)
        {
            string result = $"{warningLevels}, Message: {Message}";
            LogMessages.AppendLine(result);
            Console.WriteLine(result);
        }

        public void SaveLogFile()
        {
            File.WriteAllText(DateTime.Now.ToFileTimeUtc().ToString() + ".txt", LogMessages.ToString());
        }
    }
}
