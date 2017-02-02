using System;
using System.Collections.Generic;

namespace SuperSerilogger
{
    public class UtilizationLogStructure
    {
        public DateTime timestamp { get; set; }
        public string product_name { get; set; }
        public string product_location { get; set; }
        public string product_module { get; set; }
        public string product_workflow { get; set; }
        public string product_step { get; set; }
        public string site_name { get; set; }
        public int? site_id { get; set; }
        public string pmc_name { get; set; }
        public int? pmc_id { get; set; }
        public string user_name { get; set; }
        public int? user_id { get; set; }      
        public string logtime { get; set; }
        public Dictionary<string, object> message { get; set; }
     }
}
