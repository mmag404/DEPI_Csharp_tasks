using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    internal class Calculator
    {
        // Add two integers
        public int Sum(int a, int b)
        {
            return a + b;
        }

        // Add three integers
        public int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        // Add two doubles
        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
