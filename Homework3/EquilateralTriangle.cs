using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class EquilateralTriangle
    {
        public double Side { get; set; }

        private EquilateralTriangle() { }

        public EquilateralTriangle(double length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }
            this.Side = length;
        }

        public double GetHeight()
        {
            return this.Side * Math.Sqrt(3) / 2;
        }

        public double GetArea()
        {
            return this.Side * this.GetHeight() / 2;
        }

        public Circle GetCircleContainer()
        {
            return new Circle(this.Side * Math.Sqrt(3));
        }
    }
}
