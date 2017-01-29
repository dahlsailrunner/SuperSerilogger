using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSerilogger
{
    public enum LogType
    {
        Diagnostic,   // Debugging, informational -- rarely used
        Performance,  // Perf stats -- requires an ellapsed milliseconds
        Utilization,  // usage stats -- used to track usage of a feature
        Error,        // general exception logging
        Fatal         // critical error being logged indicated "application down"
    }
}
