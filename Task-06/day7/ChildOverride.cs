using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    // Using override keyword
    internal class ChildOverride : Parent
    {
        public int Z { get; set; }

        public ChildOverride(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override int Product()
        {
            return X * Y * Z;
        }
    }
}
