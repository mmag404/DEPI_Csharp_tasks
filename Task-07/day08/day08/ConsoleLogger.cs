using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class ConsoleLogger : ILogger
    {
        // Override default implementation
        public void Log()
        {
            Console.WriteLine("Logging from ConsoleLogger class");
        }
    }
}
