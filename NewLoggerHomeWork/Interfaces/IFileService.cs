// <copyright file="IFileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    /// <summary>
    /// must have funks!.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        void Write(string text);

        /// <summary>
        /// Delete File.
        /// </summary>
        /// <param name="path">path to file.</param>
        void DeleteFile(string path);

        /// <summary>
        /// Check Directory, if not exist - create!.
        /// </summary>
        void CheckDirectory();

        /// <summary>
        /// Check count of log files and their age.
        /// </summary>
        void CheckFilesInDirect();
    }
}
