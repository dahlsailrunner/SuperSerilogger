using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;

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
                .WriteTo.File(formatter: new UtilizationJsonFormatter("UtilizationLogStructure"), path: "api-utilization.json")
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,                    
                    CustomFormatter = new UtilizationJsonFormatter("UtilizationLogStructure"),
                    TypeName = "api-utilization",  // assigned                    
                    IndexFormat = "api-utilization-{0:yyy.MM.dd}" 
                })                
                //.WriteTo.File(formatter: new ElasticsearchJsonFormatter(), path: "log.json")
                
                //.ReadFrom.AppSettings(settingPrefix: "utilization", filePath: @"C:\Users\edahl\Source\Repos\SuperSerilogger\SuperSerilogger\logging.config")
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                //.ReadFrom.AppSettings(settingPrefix: "error", filePath: @"C:\Users\edahl\Source\Repos\SuperSerilogger\SuperSerilogger\logging.config")
                .WriteTo.File(formatter: new UtilizationJsonFormatter("UtilizationLogStructure"), path: "api-exceptions.json")
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,                    
                    CustomFormatter = new UtilizationJsonFormatter("UtilizationLogStructure"),
                    TypeName = "api-exceptions",                    
                    IndexFormat = "api-exceptions-{0:yyy.MM.dd}"
                })
                .CreateLogger();            
        }       

        public static void Write(LogInfo infoToLog)
        {            
            var objToLog = new UtilizationLogStructure();
            objToLog.product_name = infoToLog.ProductName;
            objToLog.product_location = infoToLog.ProductLocation;
            objToLog.product_module = infoToLog.ProductModule;
            objToLog.product_step = infoToLog.ProductStep;
            objToLog.product_workflow = infoToLog.ProductWorkflow;
            objToLog.pmc_id = string.IsNullOrEmpty(infoToLog.PmcId) ?  null : (int?)int.Parse(infoToLog.PmcId);
            objToLog.pmc_name = infoToLog.PmcName;
            objToLog.site_id = string.IsNullOrEmpty(infoToLog.SiteId) ? null: (int?)int.Parse(infoToLog.SiteId);
            objToLog.site_name = infoToLog.SiteName;
            objToLog.user_id = string.IsNullOrEmpty(infoToLog.UserId) ? null: (int?)int.Parse(infoToLog.UserId);
            objToLog.user_name = infoToLog.UserName;
            objToLog.logtime = infoToLog.SenderTimestamp;
            objToLog.timestamp = DateTime.Now; 

            // only set the "message" property if we have additional stuff and/or an exception to log
            if ((infoToLog.AdditionalProperties != null && infoToLog.AdditionalProperties.Count > 0) ||
                infoToLog.MessageException != null)
            {
                objToLog.message = new Dictionary<string, object>();
                if (infoToLog.AdditionalProperties != null)
                {
                    foreach (var key in infoToLog.AdditionalProperties.Keys)
                    {
                        objToLog.message.Add(key, infoToLog.AdditionalProperties[key]);
                    }
                }
                if (infoToLog.MessageException != null)
                    objToLog.message.Add("exception", infoToLog.MessageException);
            }


            // At this point we are ready to actually write the log entry
            if (infoToLog.MessageException != null)
            {
                _errorLogger.Information("{@UtilizationLogStructure}", objToLog);                
            }
            if (infoToLog.LogType == LogType.Utilization)
            {
                _informationLogger.Information("{@UtilizationLogStructure}", objToLog);
            }
        }
    }
}
