// <copyright file="FileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;
    using System.IO;

    /// <summary>
    /// FileService created for writing messages to file.
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// path of directory where stored all logs.
        /// </summary>
        public static readonly string DirectoryPath = "Logs\\";
        private const string FileExtension = ".txt";
        private const int CountSavedLogs = 3;
        private static readonly FileService InstanceValue = new FileService();
        private readonly string fileName;
        private readonly TimeSpan fileLifetime = new TimeSpan(2, 0, 0, 0, 0);

        private FileService()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            var filesPath = Directory.GetFiles(DirectoryPath, $"*{FileExtension}", SearchOption.TopDirectoryOnly);

            Array.Sort(filesPath, new FilePathDateComparer());

            for (var i = 0; i < filesPath.Length; i++)
            {
                var fileCreationTime = File.GetCreationTimeUtc(filesPath[i]);
                if (fileCreationTime < DateTime.UtcNow.Add(-this.fileLifetime) || i >= CountSavedLogs - 1)
                {
                    File.Delete(filesPath[i]);
                }
            }

            this.fileName = $"{DateTime.UtcNow:hh.mm.ss dd.MM.yyyy}{FileExtension}";
        }

        /// <summary>
        /// Gets instance of Logger setting for sigleton pattern release.
        /// </summary>
        public static FileService Instance => InstanceValue;

        /// <summary>
        /// Funk for convert file path to file name.
        /// </summary>
        /// <param name="str">File path.</param>
        /// <returns>File Name.</returns>
        public static string GetFileName(string str)
        {
            string[] result = str.Replace($"{FileExtension}", string.Empty).Replace(FileService.DirectoryPath, string.Empty).Split(' ');
            return $"{result[1].Replace(".", "/")} {result[0].Replace(".", ":")}";
        }

        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        public void Write(string text)
        {
            File.AppendAllText($"{DirectoryPath}{this.fileName}", text);
        }
    }
}
