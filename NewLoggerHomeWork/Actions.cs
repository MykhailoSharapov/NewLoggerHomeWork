using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLoggerHomeWork
{
    public class Actions
    {
        public void MethodFirst()
        {
            Logger log = Logger.GetInstance();
            log.Info(GlobalConstans.WarningLevels.Info, "Start method:" + nameof(MethodFirst));

        }
        public void MethodSecond()
        {
            Logger log = Logger.GetInstance();
            log.Info(GlobalConstans.WarningLevels.Warning, "Skipped logic in method:" + nameof(MethodSecond));
        }
        public void MethodThird()
        {
            throw new Exception("I broke a toilet");
        }
    }
}
