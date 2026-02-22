using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public struct Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override string ToString()
        {
            return $"Length = {Length}, Width = {Width}";   
        }
    }
}
