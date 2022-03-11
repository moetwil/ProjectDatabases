using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace SomerenLogic
{
    public static class LoggerService
    {
        public static void WriteLog(Exception ex)
        {
            // location of the logfile
            string logPath = ConfigurationManager.AppSettings["logPath"];

            // streamwriter that adds the information to the logfile
            using(StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {ex.Message} | {ex}");
                writer.WriteLine();
            }

        }
    }
}
