using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewLoggerHomeWork
{
    public class Logger
    {        
        private static readonly Logger _instance = new Logger();
        private static readonly StringBuilder _messages = new StringBuilder();
        private Logger()
        {
           
        }
        public static StringBuilder Messages => _messages;
        public static Logger Instance => _instance;
        public void LogError(string message, Exception ex = null)
        {
            var result = $"LogLevel: {LogLevel.Error}: {message}";
            if (ex != null)
            {
                result += $" stacktrace: {ex.StackTrace}";
            }
            Messages.AppendLine(result);
            Console.WriteLine(result);
        }
        public void LogInfo(string message)
        {
            Log(LogLevel.Info, message);
        }
        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }
        public void Log(LogLevel logLevels, string message)
        {
            var result = $"LogLevel: {logLevels}, Message: {message}";
            Messages.AppendLine(result);
            Console.WriteLine(result);
        }
    }
}
