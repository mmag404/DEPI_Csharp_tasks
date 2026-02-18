using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class Robot : IWalkable
    {
        // Normal class method
        public void Walk()
        {
            Console.WriteLine("Robot walking normally (class method)");
        }

        // Explicit interface implementation
        void IWalkable.Walk()
        {
            Console.WriteLine("Robot walking using IWalkable interface (explicit implementation)");
        }
    }
}
