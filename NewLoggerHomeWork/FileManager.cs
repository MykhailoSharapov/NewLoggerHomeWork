using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewLoggerHomeWork
{
    public class FileManager
    {
        public void SaveLogReportInFile(Logger logger)
        {
            File.WriteAllText($"{DateTime.UtcNow.ToFileTime().ToString()}.txt", logger.Messages.ToString());
        }
    }
}
