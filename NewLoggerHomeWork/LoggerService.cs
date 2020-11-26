using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewLoggerHomeWork
{
    public class LoggerService
    {
        private readonly Logger _logger;
        
        public LoggerService()
        {
            _logger = Logger.Instance;
        }
        public void SaveLogReportInFile(string path)
        {
            if(File.Exists(path))
            {
                throw new Exception("File exist!");
            }
            File.WriteAllText(path, Logger.Messages.ToString());
        }
    }
}
