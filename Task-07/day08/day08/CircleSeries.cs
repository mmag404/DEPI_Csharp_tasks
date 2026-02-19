using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class CircleSeries : IShapeSeries
    {
        private int radius = 1;

        public int CurrentShapeArea { get; set; }

        public CircleSeries()
        {
            CurrentShapeArea = (int)(Math.PI * radius * radius);
        }

        public void GetNextArea()
        {
            radius++;
            CurrentShapeArea = (int)(Math.PI * radius * radius);
        }

        public void ResetSeries()
        {
            radius = 1;
            CurrentShapeArea = (int)(Math.PI * radius * radius);
        }
    }
}
