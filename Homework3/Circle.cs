using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Circle
    {
        // Radius
        public double Radius { get; set; }

        // No 'empty' circle
        private Circle() { }

        // Constructor with radius, no negative value
        public Circle(double length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }
            this.Radius = length;
        }

        // Area of circle
        // MathPow: <1st number> ^ <2nd number>
        // Math.PI: 3.1415...
        public double GetArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        // Triangle container
        // Math.Sqrt: <number> ^ (1/2)
        public EquilateralTriangle GetTriangleContainer()
        {
            return new EquilateralTriangle(this.Radius * Math.Sqrt(12));
        }
    }
}
