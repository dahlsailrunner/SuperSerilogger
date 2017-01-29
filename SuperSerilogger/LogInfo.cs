using System;
using System.Collections.Generic;

namespace SuperSerilogger
{
    public class LogInfo
    {
        public LogType LogType { get; set; }
        public string ProductName { get; set; }
        public string ProductLocation { get; set; }
        public string ProductModule { get; set; }
        public string ProductWorkflow { get; set; }
        public string ProductStep { get; set; }
        public string SiteName { get; set; }
        public string SiteId { get; set; }
        public string PmcName { get; set; }
        public string PmcId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string SenderTimestamp { get; set; }
        public string ReferringUrl { get; set; }
        public IDictionary<string, object> AdditionalProperties { get; set; }
        public Exception MessageException { get; set; }

        public LogInfo(LogType type)
        {
            LogType = type;
        }

    }
}
