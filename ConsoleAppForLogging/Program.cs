using SuperSerilogger;
using System;

namespace ConsoleAppForLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new LogInfo(LogType.Utilization);
            info.SenderTimestamp = DateTime.Now.ToString("O");
            info.PmcId = "12354";
            info.PmcName = "Dahl Properties";

            SuperLogger.Write(info);

            try
            {
                var exceptional = new Exception("Craziness!");
                exceptional.Data.Add("CustomProp", "Wowweeee");
                exceptional.Data.Add("Unbelievable", "We did it!");
                throw exceptional;
            }
            catch (Exception ex)
            {
                var logMsg = new LogInfo(LogType.Utilization);
                logMsg.SenderTimestamp = DateTime.Now.ToString("O");
                logMsg.MessageException = ex;
                SuperLogger.Write(logMsg);
            }

            Console.ReadLine();
        }
    }
}
