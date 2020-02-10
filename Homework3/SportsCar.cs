using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class SportsCar : VintageCar
    {
        public bool IsHybrid { get; set; }

        protected SportsCar() { }

        public SportsCar(string model, double weight,
                          double height) : base(model, weight, height)
        {
            this.IsHybrid = false;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $", Hybrid: {((this.IsHybrid) ? "Yes" : "No")}";
        }
    }
}
