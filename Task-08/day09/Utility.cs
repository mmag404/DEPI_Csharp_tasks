using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public static class Utility
    {
        private const double pi = 3.14;

        public static double Pi
        {
            get { return pi; }
        }

        public static double CmToInch(double cm)
        {
            return cm / 2.54;
        }

        public static double CalcCircleArea(double Radius)
        {
            return Pi * Radius * Radius;
        }


        #region static method - rectangle perimeter
        public static double CalcRectanglePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }
        #endregion

        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
