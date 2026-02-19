using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class SquareSeries : IShapeSeries
    {
        private int side = 1;

        public int CurrentShapeArea { get; set; }

        public SquareSeries()
        {
            CurrentShapeArea = side * side;
        }

        public void GetNextArea()
        {
            side++;
            CurrentShapeArea = side * side;
        }

        public void ResetSeries()
        {
            side = 1;
            CurrentShapeArea = side * side;
        }
    }
}
