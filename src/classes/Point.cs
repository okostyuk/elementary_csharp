using System;

namespace csharp1.classes
{
    public class Point
    {
        private String name;
        private int valueY;
        private int valueX;

        public int X { get { return valueX; } }
        public int Y { get { return valueY; } }
        public String Name { get { return name; } }

        public Point(String name, int x, int y) {
            this.valueX = x;
            this.valueY = y;
            this.name = name;
        }        
    }
}