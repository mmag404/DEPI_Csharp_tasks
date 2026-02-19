using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class SortableShape : IComparable<SortableShape>
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public SortableShape(string name, double area)
        {
            Name = name;
            Area = area;
        }

        public int CompareTo(SortableShape other)
        {
            return this.Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"Shape: {Name}, Area: {Area}";
        }
    }
}
