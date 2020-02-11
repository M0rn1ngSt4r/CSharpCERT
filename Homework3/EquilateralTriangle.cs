using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class EquilateralTriangle
    {
        // Side length, an equilateral triangle has 3 equal sides
        public double Side { get; set; }

        // No 'empty' triangle
        private EquilateralTriangle() { }

        // Constructor with side length, no negative values
        public EquilateralTriangle(double length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }
            this.Side = length;
        }

        // Height only with side length
        public double GetHeight()
        {
            return this.Side * Math.Sqrt(3) / 2;
        }

        // Area of triangle
        public double GetArea()
        {
            return this.Side * this.GetHeight() / 2;
        }

        // Circumcircle
        public Circle GetCircleContainer()
        {
            return new Circle(this.Side * Math.Sqrt(3));
        }
    }
}
