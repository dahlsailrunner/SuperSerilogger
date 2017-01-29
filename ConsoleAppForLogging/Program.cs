using SuperSerilogger;
using System;

namespace ConsoleAppForLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new LogInfo(LogType.Utilization);

            SuperLogger.Write(info);

            try
            {
                var exceptional = new Exception("Craziness!");
                exceptional.Data.Add("CustomProp", "Wowweeee");
                throw exceptional;
            }
            catch (Exception ex)
            {
                var logMsg = new LogInfo(LogType.Utilization);
                logMsg.MessageException = ex;
                SuperLogger.Write(logMsg);
            }

            Console.ReadLine();
        }
    }
}
