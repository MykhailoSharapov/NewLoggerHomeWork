// <copyright file="FilePathDateComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;
    using System.Collections;

    /// <summary>
    /// Custom data comparer for sorting file names via date.
    /// </summary>
    public class FilePathDateComparer : IComparer
    {
        /// <summary>
        /// funk for compairing filepath via date.
        /// </summary>
        /// <param name="x">first date.</param>
        /// <param name="y">second date.</param>
        /// <returns>int result of compairing.</returns>
        public int Compare(object x, object y)
        {
            x = this.GetFileName(x.ToString());
            y = this.GetFileName(y.ToString());
            if (DateTime.TryParse(x.ToString(), out DateTime dateTime1) && DateTime.TryParse(y.ToString(), out DateTime dateTime2))
            {
                if (dateTime1 < dateTime2)
                {
                    return 1;
                }
                else if (dateTime1 > dateTime2)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Invalid logFile name");
            }
        }

        /// <summary>
        /// Funk for convert file path to file name.
        /// </summary>
        /// <param name="str">File path.</param>
        /// <returns>File Name.</returns>
        private string GetFileName(string str)
        {
            string[] result = str.Replace(".txt", string.Empty).Replace(FileService.DirectoryPath, string.Empty).Split(' ');
            return $"{result[1].Replace(".", "/")} {result[0].Replace(".", ":")}";
        }
    }
}
