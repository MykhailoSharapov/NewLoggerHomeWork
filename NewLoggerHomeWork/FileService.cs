using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewLoggerHomeWork
{
    public class FileService
    {
        public void WriteFile(string path,string text)
        {
            if(File.Exists(path))
            {
                throw new Exception("File exist!");
            }
            File.WriteAllText(path, text);
        }
    }
}
