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
        private StringBuilder LogMessages = new StringBuilder();
        private static readonly Logger _instance = new Logger();
        public static Logger Instance => _instance;
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

        public StringBuilder GetLogReport()
        {
            return LogMessages;
        }
    }
}
