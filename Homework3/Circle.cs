using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Circle
    {
        public double Radius { get; set; }

        private Circle() { }

        public Circle(double length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }
            this.Radius = length;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public EquilateralTriangle GetTriangleContainer()
        {
            return new EquilateralTriangle(this.Radius * Math.Sqrt(12));
        }
    }
}
