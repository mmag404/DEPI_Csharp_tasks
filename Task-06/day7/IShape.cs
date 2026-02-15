using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    internal interface IShape
    {
        double Area { get; }
        void Draw();


        // Default implementation
        void PrintDetails()
        {
            Console.WriteLine("This is a shape. Area = " + Area);
        }
    }
}
