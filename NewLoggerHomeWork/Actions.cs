// <copyright file="Actions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;

    /// <summary>
    /// Actions class imitate working some real class where will used this logger.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// global variable for using logger functions.
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Actions"/> class.
        /// and initiates logger.
        /// </summary>
        public Actions()
        {
            this.logger = Logger.Instance;
        }

        /// <summary>
        /// Method for call logger to write message with level = info.
        /// </summary>
        public void MethodFirst()
        {
            this.logger.LogInfo($"Start method:{nameof(this.MethodFirst)}");
        }

        /// <summary>
        /// Method for call logger to thow new custom exception.
        /// </summary>
        public void MethodSecond()
        {
            throw new BusinesException($"Skipped logic in method:{nameof(this.MethodSecond)}");
        }

        /// <summary>
        /// Method for call logger to thow new custom exception.
        /// </summary>
        public void MethodThird()
        {
            throw new Exception("I broke a toilet");
        }
    }
}
