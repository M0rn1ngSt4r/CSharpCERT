using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class ComplexNumber
    {
        // Real part
        public double RealPart { get; set; }
        // Imaginary part
        public double ImaginaryPart { get; set; }

        // Default constructor 0 + 0i
        public ComplexNumber()
        {
            this.RealPart = 0;
            this.ImaginaryPart = 0;
        }

        // Custom construtor, both parts
        public ComplexNumber(double real, double imaginary)
        {
            this.RealPart = real;
            this.ImaginaryPart = imaginary;
        }

        // Static method, validate numbers are not null
        public static ComplexNumber Add(ComplexNumber cn1, ComplexNumber cn2)
        {
            if (cn1 == null || cn2 == null)
            {
                return null;
            }
            // Addition by parts
            return new ComplexNumber(cn1.RealPart + cn2.RealPart,
                                     cn1.ImaginaryPart + cn2.ImaginaryPart);
        }

        // To string method, formatting negative case 
        public override string ToString()
        {
            if (this.ImaginaryPart < 0)
            {
                // Math.Abs only used for string format (redundant)
                return $"{this.RealPart} - {Math.Abs(this.ImaginaryPart)}i";
            }
            return $"{this.RealPart} + {this.ImaginaryPart}i";
        }
    }
}
