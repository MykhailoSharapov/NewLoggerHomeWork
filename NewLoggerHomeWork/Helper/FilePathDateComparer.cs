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
        /// Initializes a new instance of the <see cref="FilePathDateComparer"/> class.
        /// </summary>
        public FilePathDateComparer()
        {
        }

        /// <summary>
        /// funk for compairing filepath via date.
        /// </summary>
        /// <param name="x">first date.</param>
        /// <param name="y">second date.</param>
        /// <returns>int result of compairing.</returns>
        public int Compare(object x, object y)
        {
            var fileName1 = FileService.GetFileName(x.ToString());
            var fileName2 = FileService.GetFileName(y.ToString());
            if (DateTime.TryParse(fileName1, out DateTime dateTime1) && DateTime.TryParse(fileName2, out DateTime dateTime2))
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
    }
}
