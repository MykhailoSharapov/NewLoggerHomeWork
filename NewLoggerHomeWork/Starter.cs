using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewLoggerHomeWork
{
    public class Starter
    {
        private readonly Actions _actions;
        private readonly Logger _logger;
        public Starter()
        {
            _actions = new Actions();
            _logger = Logger.Instance;
        }
        public void Run()
        {

            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var funcRandNum = rand.Next(1, 4);
                    switch (funcRandNum)
                    {
                        case 1:
                            _actions.MethodFirst();
                            break;
                        case 2:
                            _actions.MethodSecond();
                            break;
                        case 3:
                            _actions.MethodThird();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex);
                }
            }

            File.WriteAllText($"{ DateTime.UtcNow.ToFileTime().ToString()}.txt", _logger.GetLogReport().ToString());
        }
    }
}
