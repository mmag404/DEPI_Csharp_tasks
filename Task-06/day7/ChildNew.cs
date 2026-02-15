using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    // Using new keyword
    internal class ChildNew : Parent
    {
        public int Z { get; set; }

        public ChildNew(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public new int Product()
        {
            return X * Y * Z;
        }
    }

    
}
