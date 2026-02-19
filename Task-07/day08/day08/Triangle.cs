using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class Triangle : GeometricShape
    {
        public Triangle(double baseValue, double height)
            : base(baseValue, height)
        {
        }

        public override double CalculateArea()
        {
            return 0.5 * Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get
            {
                // Assuming right triangle for simplicity
                double hypotenuse = Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
                return Dimension1 + Dimension2 + hypotenuse;
            }
        }
    }
}
