using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewLoggerHomeWork
{
    public class Logger
    {        
        private static readonly Logger _instance = new Logger();
        private Logger()
        {
            Messages = new StringBuilder();
        }
        public StringBuilder Messages { get; private set; }        
        public static Logger Instance => _instance;
        public void LogError(string message, Exception ex = null)
        {
            var result = $"{LogLevel.Error}: {message}";
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
        public void Log(LogLevel warningLevels, string Message)
        {
            var result = $"{warningLevels}, Message: {Message}";
            Messages.AppendLine(result);
            Console.WriteLine(result);
        }
    }
}
