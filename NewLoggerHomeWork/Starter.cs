// <copyright file="Starter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NewLoggerHomeWork
{
    using System;

    /// <summary>
    /// Starter class using for start testing our algoritms.
    /// </summary>
    public class Starter
    {
        private readonly Actions actions;
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Starter"/> class.
        /// And initialize Logger and ations.
        /// </summary>
        public Starter()
        {
            this.actions = new Actions();
            this.logger = Logger.Instance;
        }

        /// <summary>
        /// funk for random call testing functions.
        /// </summary>
        public void Run()
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            this.actions.MethodFirst();
                            break;
                        case 2:
                            this.actions.MethodSecond();
                            break;
                        case 3:
                            this.actions.MethodThird();
                            break;
                    }
                }
                catch (BusinesException bex)
                {
                    this.logger.LogWarning($"Action got this custom Exception :{bex}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex.Message, ex);
                }
            }
        }
    }
}
