using System;

namespace csharp1.classes
{
    public class Rectangle {
        public double Side1 { get; set; }
        public double  Side2 { get; set; }

        public Rectangle(double side1, double side2)
        {
            this.Side1 = side1;
            this.Side2 = side2;
        }

        public double AreaCalculator() {
            return Side1 * Side2;
        }

        public double PerimeterCalculator()
        {
            return (Side1 + Side2)*2d;
        }

    }
}