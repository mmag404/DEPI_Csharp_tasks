using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    internal class ShapeFactory
    {
        public static GeometricShape CreateShape(string shapeType, double dim1, double dim2)
        {
            shapeType = shapeType.ToLower();

            if (shapeType == "triangle")
            {
                return new Triangle(dim1, dim2);
            }
            else if (shapeType == "rectangle")
            {
                return new GeoRectangle(dim1, dim2);
            }
            else
            {
                throw new ArgumentException("Invalid shape type");
            }
        }

    }
}
