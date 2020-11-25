using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLoggerHomeWork
{
    public class Actions
    {
        Logger log;
        public Actions()
        {
            log = Logger.GetInstance();
        }
        public void MethodFirst()
        {
            log.Info(GlobalConstans.WarningLevels.Info, "Start method:" + nameof(MethodFirst));

        }
        public void MethodSecond()
        {
            log.Info(GlobalConstans.WarningLevels.Warning, "Skipped logic in method:" + nameof(MethodSecond));
        }
        public void MethodThird()
        {
            throw new Exception("I broke a toilet");
        }
    }
}
