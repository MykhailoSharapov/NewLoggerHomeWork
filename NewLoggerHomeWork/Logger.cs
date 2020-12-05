using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewLoggerHomeWork
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        //private static readonly StringBuilder _messages = new StringBuilder();
        private readonly FileService _fileService;
        private Logger()
        {
            _fileService = FileService.Instance;
        }
        //public static StringBuilder Messages => _messages;
        public static Logger Instance => _instance;
        public void LogError(string message, Exception ex = null)
        {
            //var result = $"LogLevel: {LogLevel.Error}, Message: {message}";
              var result = $"{DateTime.UtcNow.ToString("hh:mm:ss")}:{LogLevel.Error}:{message}";
            if (ex != null)
            {
                result += $":{ex}";
            }

            _fileService.Write($"{result}{Environment.NewLine}");
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
        public void Log(LogLevel logLevel, string message)
        {
            //var result = $"LogLevel: {logLevels}, Message: {message}";
            var result = $"{DateTime.UtcNow.ToString("hh:mm:ss")}:{logLevel}:{message} {Environment.NewLine}";
            _fileService.Write(result);
            Console.WriteLine(result);
        }
    }
}
