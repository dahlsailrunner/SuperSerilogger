using Newtonsoft.Json;
using Serilog;


namespace SuperSerilogger
{    
    public static class SuperLogger
    {
        private static readonly ILogger _informationLogger;
        private static readonly ILogger _errorLogger;

        static SuperLogger()
        {            
            _informationLogger = new LoggerConfiguration()
                //.WriteTo.ColoredConsole()                
                //.WriteTo.File()
                .ReadFrom.AppSettings(settingPrefix: "utilization", filePath: @"C:\Users\edahl\Source\Repos\SuperSerilogger\SuperSerilogger\logging.config")
                .CreateLogger();            

            _errorLogger = new LoggerConfiguration()
                .ReadFrom.AppSettings(settingPrefix: "error", filePath: @"C:\Users\edahl\Source\Repos\SuperSerilogger\SuperSerilogger\logging.config")
                .CreateLogger();
        }

        public static void Write(LogInfo infoToLog)
        {
            var json = JsonConvert.SerializeObject(infoToLog);

            if (infoToLog.MessageException != null)
            {
                _errorLogger.Error(infoToLog.MessageException, "{@LogInfo}", infoToLog);
            }

            if (infoToLog.LogType == LogType.Utilization)
            {               
                _informationLogger.Information(messageTemplate: "Hello World!");
            }
        }
    }
}
