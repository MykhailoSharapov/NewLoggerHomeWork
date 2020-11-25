using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLoggerHomeWork
{
    public class Actions
    {
        private readonly Logger _logger;
        public Actions()
        {
            _logger = Logger.Instance;
        }
        public void MethodFirst()
        {
            _logger.LogInfo($"Start method:{nameof(MethodFirst)}");

        }
        public void MethodSecond()
        {
            _logger.LogWarning($"Skipped logic in method:{nameof(MethodSecond)}");
        }
        public void MethodThird()
        {
            throw new Exception("I broke a toilet");
        }
    }
}
