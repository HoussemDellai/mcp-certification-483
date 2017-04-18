using System;
using System.Configuration;
using System.Diagnostics;

namespace AppConfigExamples
{
    class Program
    {
        private static BooleanSwitch boolSwitch = new BooleanSwitch("mySwitch", "BooleanSwitch in config file");
        private static TraceSwitch traceSwitch = new TraceSwitch("myTraceSwitch", "Trace Switch in config file");

        static void Main(string[] args)
        {
            // --- Switches
            //BooleanSwitch (ein/aus)
            Console.WriteLine("Boolean switch {0} configured as {1}",
                   boolSwitch.DisplayName, boolSwitch.Enabled.ToString());
            //TraceSwitch (Multi-Level)
            // 1 = Error
            // 2 = Warning
            // 3 = Info
            // 4 = Verbose
            if (traceSwitch.Level >= TraceLevel.Error)
            {
                Console.WriteLine("we trace errors");
            }
            if (traceSwitch.Level >= TraceLevel.Warning)
            {
                Console.WriteLine("we trace warnings");
            }
            if (traceSwitch.Level >= TraceLevel.Info)
            {
                Console.WriteLine("we trace Info");
            }
            if (traceSwitch.Level >= TraceLevel.Verbose)
            {
                Console.WriteLine("we trace Verbose");
            }

            // --- Variables in app.config (all strings, return null if not defined):
            string baseDir = ConfigurationManager.AppSettings["MyBaseDir"];
            if (baseDir != null)
            {
                Console.WriteLine("Base Dir: {0}", baseDir);
            }
            int tenFromConfig;
            if (!int.TryParse(ConfigurationManager.AppSettings["ten"], out tenFromConfig))
            {
                Console.WriteLine("cannot parse AppSetting 'ten' from app.config to an int.");
            }
            else
            {
                Console.WriteLine("'ten' is defined as {0}", tenFromConfig);
            }

            // Database connect strings
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["ManinDB"].ConnectionString;
            Console.WriteLine("Connect String: {0}", connection.ToString());


        }
    }
}
