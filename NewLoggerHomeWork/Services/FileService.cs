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
        private const int CountSavedLogs = 3;
        private static readonly FileService InstanceValue = new FileService();
        private static string fileName;

        private FileService()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            string[] filesPath = Directory.GetFiles(DirectoryPath, "*.txt", SearchOption.TopDirectoryOnly);

            Array.Sort(filesPath, new FilePathDateComparer());

            for (var i = 0; i < filesPath.Length; i++)
            {
                DateTime fileCreationTime = File.GetCreationTimeUtc(filesPath[i]);
                if (fileCreationTime.AddDays(2) < DateTime.UtcNow || i + 2 > CountSavedLogs)
                {
                    File.Delete(filesPath[i]);
                }
            }

            fileName = $"{DateTime.UtcNow:hh.mm.ss dd.MM.yyyy}.txt";
        }

        /// <summary>
        /// Gets instance of Logger setting for sigleton pattern release.
        /// </summary>
        public static FileService Instance => InstanceValue;

        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        public void Write(string text)
        {
            File.AppendAllText($"{DirectoryPath}{fileName}", text);
        }
    }
}
