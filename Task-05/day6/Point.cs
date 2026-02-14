using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    #region PointStruct for q1 and q4 and q5


    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x)
        {
            X = x;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            // q1
            // return $"({X}, {Y})";

            // q5
            return $"Point => X: {X}, Y: {Y}";
        }
    }

    /*
    Answer for Q1:

    Struct cannot inherit from another struct or class because it is a value type.
    Value types do not support inheritance. Structs implicitly inherit from
    System.ValueType and cannot inherit from any other type.
    They can only implement interfaces.
    */

    #endregion

}
