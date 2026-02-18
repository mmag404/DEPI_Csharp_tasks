using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public interface ILogger
    {
        // Default implementation
        void Log()
        {
            Console.WriteLine("Default logging from ILogger");
        }
    }
}
