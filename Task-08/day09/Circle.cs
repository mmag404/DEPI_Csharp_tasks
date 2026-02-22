using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public struct Circle
    {
        public double Radius { get; set; }
        public string Color { get; set; }

       /* public override bool Equals(object obj)
        {
            if (!(obj is Circle))
                return false;

            Circle other = (Circle)obj;

            return this.Radius == other.Radius &&
                   this.Color == other.Color;
        }*/

        public override string ToString()
        {
            return $"Radius = {Radius}, Color = {Color}";
        }
    }
}
