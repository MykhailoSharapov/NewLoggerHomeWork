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
        public static string _directoryPath = "Logs\\";
        private static readonly FileService _instance = new FileService();
        private static string _fileName;
        private const int _countSavedLogs = 3;
        private FileService()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            string[] filesPath = Directory.GetFiles(_directoryPath, "*.txt", SearchOption.TopDirectoryOnly);
            
            Array.Sort(filesPath, new FilePathDateComparer());

            for (var i = 0; i < filesPath.Length; i++)
            {
                DateTime fileCreationTime = File.GetCreationTimeUtc(filesPath[i]);
                if (fileCreationTime.AddDays(2) < DateTime.UtcNow || i+2 > _countSavedLogs)
                {
                    File.Delete(filesPath[i]);
                }
            }
            _fileName = $"{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
        }
        public static FileService Instance => _instance;
        public void Write(string text)
        {
            File.AppendAllText($"{_directoryPath}{_fileName}", text);
        }
    }
}
