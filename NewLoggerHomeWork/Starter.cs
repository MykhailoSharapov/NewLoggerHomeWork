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
        private readonly FileService _fileService;
        public Starter()
        {
            _actions = new Actions();
            _logger = Logger.Instance;
            _fileService = new FileService();
        }
        public void Run()
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (rand.Next(1, 4))
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
                    _logger.LogError(ex.Message, ex);
                }
            }
            try
            {
                var fileName = $"{DateTime.UtcNow.ToFileTime().ToString()}.txt";
                _fileService.WriteFile(fileName, Logger.Messages.ToString());
                _logger.LogInfo($"{fileName} saved succesfull!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Saving report error!", ex);
            }
        }
    }
}
