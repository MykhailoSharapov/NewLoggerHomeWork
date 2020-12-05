// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;

    /// <summary>
    /// Logger class to create log messages.
    /// </summary>
    public class Logger : ILogger
    {
        private static readonly Logger InstanceValue = new Logger();
        private readonly FileService fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Construcor of logger need initialize fileservice to work with him.
        /// </summary>
        private Logger()
        {
            this.fileService = FileService.Instance;
        }

        /// <summary>
        /// Gets instance of logger to transfer it in plases where it will uses.
        /// </summary>
        public static Logger Instance => InstanceValue;

        /// <summary>
        /// Funk for write log with level error.
        /// </summary>
        /// <param name="message">text message.</param>
        /// <param name="ex">exception or null.</param>
        public void LogError(string message, Exception ex = null)
        {
            var result = $"{DateTime.UtcNow:hh:mm:ss}:{LogLevel.Error}:{message}";

            if (ex != null)
            {
                result += $":{ex}";
            }

            this.fileService.Write($"{result}{Environment.NewLine}");
            Console.WriteLine(result);
        }

        /// <summary>
        /// Funk for write log with level Info.
        /// </summary>
        /// <param name="message">text message.</param>
        public void LogInfo(string message)
        {
            this.Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Funk for write log with level warning.
        /// </summary>
        /// <param name="message">text message.</param>
        public void LogWarning(string message)
        {
            this.Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// universal method for writing all types of messadges.
        /// </summary>
        /// <param name="logLevel">log level look in enums.</param>
        /// <param name="message">text of message.</param>
        public void Log(LogLevel logLevel, string message)
        {
            var result = $"{DateTime.UtcNow:hh:mm:ss}:{logLevel}:{message} {Environment.NewLine}";
            this.fileService.Write(result);
            Console.WriteLine(result);
        }
    }
}
