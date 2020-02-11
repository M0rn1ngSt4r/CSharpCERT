using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    // Base class: VintageCar
    class SportsCar : VintageCar
    {
        // Hybrid car?
        public bool IsHybrid { get; set; }

        // No 'empty' Sports car
        protected SportsCar() { }

        // Constructor, every attribute
        public SportsCar(string model, double weight,
                          double height) : base(model, weight, height)
        {
            this.IsHybrid = false;
        }

        // String representation
        public override string ToString()
        {
            return base.ToString() +
                   $", Hybrid: {((this.IsHybrid) ? "Yes" : "No")}";
        }
    }
}
