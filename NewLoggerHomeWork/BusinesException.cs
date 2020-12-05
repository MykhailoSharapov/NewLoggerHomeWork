// <copyright file="BusinesException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;

    /// <summary>
    /// My custom BusinesException.
    /// </summary>
    public class BusinesException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinesException"/> class.
        /// Just renaming original class for filtering exceptions.
        /// </summary>
        /// <param name="message">Message of exception when user geberate new exception.</param>
        public BusinesException(string message)
            : base(message)
        {
        }
    }
}
