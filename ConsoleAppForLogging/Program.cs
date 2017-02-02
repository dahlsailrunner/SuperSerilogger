using SuperSerilogger;
using System;

namespace ConsoleAppForLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new LogInfo(LogType.Utilization);
            info.SenderTimestamp = DateTime.Now.ToString("O");//.Replace(" ", "T");

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
                logMsg.SenderTimestamp = DateTime.Now.ToString("O");//.Replace(" ", "T");
                logMsg.MessageException = ex;
                SuperLogger.Write(logMsg);
            }

            Console.ReadLine();
        }
    }
}
