using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    internal class Rectangl : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangl(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}
