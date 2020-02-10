using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class ComplexNumber
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public ComplexNumber()
        {
            this.RealPart = 0;
            this.ImaginaryPart = 0;
        }

        public ComplexNumber(double real, double imaginary)
        {
            this.RealPart = real;
            this.ImaginaryPart = imaginary;
        }

        public static ComplexNumber Add(ComplexNumber cn1, ComplexNumber cn2)
        {
            if (cn1 == null || cn2 == null)
            {
                return null;
            }
            return new ComplexNumber(cn1.RealPart + cn2.RealPart,
                                     cn1.ImaginaryPart + cn2.ImaginaryPart);
        }

        public override string ToString()
        {
            if (this.ImaginaryPart < 0)
            {
                return $"{this.RealPart} - {Math.Abs(this.ImaginaryPart)}i";
            }
            return $"{this.RealPart} + {this.ImaginaryPart}i";
        }
    }
}
