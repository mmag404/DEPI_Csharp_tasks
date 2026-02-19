using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class GeoRectangle : GeometricShape
    {
        public GeoRectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * (Dimension1 + Dimension2);
            }
        }
    }
}
