using Serilog.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using System.IO;

namespace SuperSerilogger
{
    //public class UtilitizationFormatter : DefaultJsonFormatter
    //{
    //    public void Format(LogEvent logEvent, TextWriter output)
    //    {   
                     
    //        if (logEvent.Properties.ContainsKey("LogInfo"))
    //        {
    //            var li = logEvent.Properties["LogInfo"] as StructureValue;
                
    //        }

    //        var message = logEvent.RenderMessage();
    //        //WriteRenderedMessage(message, ref delim, output);

    //        var e = logEvent;
    //    }        
    //}    
}
