using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    #region Circle class

    public class CircleClass
    {
        public double Radius { get; set; }
        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            CircleClass other = obj as CircleClass;

            if (other == null)
                return false;

            return this.Radius == other.Radius &&
                   this.Color == other.Color;
        }

        public override string ToString()
        {
            return $"Radius = {Radius}, Color = {Color}";
        }
    }

    #endregion
}
