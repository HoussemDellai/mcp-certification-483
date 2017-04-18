using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTraceListener
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example from test had Trace.Verbose, not working here. And we may not call the TraceSwitch "switch"
            // but: 1=Error, 2=Warning, 3=Info, 4=Verbose
            TraceSwitch sw = new TraceSwitch("mySwitch", null);
            if (sw.TraceError)
                Trace.TraceError("ERROR");
            if (sw.TraceWarning)
                Trace.TraceWarning("WARNING");
            if (sw.TraceInfo)
                Trace.TraceInformation("INFO");
            if (sw.TraceVerbose)
                Trace.Write("VERBOSE");
        }
    }
}
