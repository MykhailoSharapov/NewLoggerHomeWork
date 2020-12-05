using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewLoggerHomeWork
{
    public class FilePathDateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            x = GetFileName(x.ToString());
            y = GetFileName(y.ToString());
            if (DateTime.TryParse(x.ToString(),out DateTime dateTime1) && DateTime.TryParse(y.ToString(), out DateTime dateTime2))
            {

                if (dateTime1 < dateTime2)
                {
                    return 1;
                }
                else if (dateTime1 > dateTime2)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Invalid logFile name");
            }
        }
        private string GetFileName(string str)
        {
            string[] result = str.Replace(".txt", "").Replace(FileService._directoryPath, "").Split(' ');
            return $"{result[1].Replace(".","/")} {result[0].Replace(".",":")}";
        }
    }
}
