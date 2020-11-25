using System;
using System.Collections.Generic;
using System.IO;

namespace NewLoggerHomeWork
{
    class Logger
    {
        private Logger()
        {

        }
        private static Logger instance;
        private static List<string> LogMessages = new List<string>();
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
        public void NewMessage(string MessageLevel, Exception ex)
        {
            string result = $"{MessageLevel}, Action failed by reason: {ex.StackTrace}";
            LogMessages.Add(result);
            Console.WriteLine(result);
        }

        public void NewMessage(string MessageLevel, string Message)
        {
            string result = $"{MessageLevel}, Message: {Message}";
            LogMessages.Add(result);
            Console.WriteLine(result);
        }

        public void SaveLogFile()
        {
            File.AppendAllLines(DateTime.Now.Ticks.ToString() + ".txt", LogMessages);
        }
    }
}
