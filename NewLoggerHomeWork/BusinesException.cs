using System;

namespace NewLoggerHomeWork
{
    public class BusinesException : Exception
    {
        public BusinesException(string message) : base(message)
        {
        }
    }
}
