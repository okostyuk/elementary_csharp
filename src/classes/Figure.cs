using System;

namespace csharp1.classes 
{
    public class Figure {

        private String mShapeName;

        private double mPerimeter = 0;

        private int mSize = 0;
        private Point[] mPoints = new Point[5];
        
        public Figure(Point p1, Point p2, Point p3) {
            mShapeName = "Triangle";
            mPoints[0] = p1;
            mPoints[1] = p2;
            mPoints[2] = p3;
            mSize = 3;
        }

        public Figure(Point p1, Point p2, Point p3, Point p4) : this(p1, p2, p3) {
            mShapeName = "Rectangle";
            mSize = 4;
            mPoints[3] = p4;
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(p1, p2, p3, p4) {
            mShapeName = "Pentagon";
            mSize = 5;
            mPoints[4] = p5;
        }

        private double LengthSide(Point A, Point B) {
            return Math.Sqrt(
                Math.Pow(Math.Abs(A.X - B.X), 2) + 
                Math.Pow(Math.Abs(A.Y - B.Y), 2)
            );
        }

        public void PerimeterCalculator() {
            if (mPerimeter > 0 ) return;

            for (int i = 0; i<mSize-1; i++) {
                mPerimeter += LengthSide(mPoints[i], mPoints[i+1]);
            }
            mPerimeter += LengthSide(mPoints[0], mPoints[mSize-1]);
        }


        public override String ToString()
        {
            return mShapeName + ": " + mPerimeter;
        }

    }
}