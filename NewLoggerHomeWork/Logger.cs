using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLoggerHomeWork
{
    class Logger
    {
        private Logger()
        {

        }
        private static Logger instance;
        private static List<string> LogMessages = new List<string>();
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }
}
