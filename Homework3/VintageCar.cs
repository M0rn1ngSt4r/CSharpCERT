using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    // Base class: Car
    class VintageCar : Car
    {
        // Model
        public string Model { get; private set; }
        // Has turbo?
        public bool Turbo { get; set; }

        // No 'empty' VintageCar
        protected VintageCar() { }

        // Constructor, all attributes
        public VintageCar(string model, double weight,
                          double height) : base(weight, height)
        {
            this.SetModel(model);
            // No turbo by default
            this.Turbo = false;
        }

        // Validate model, no null or empty string
        public void SetModel(string model)
        {
            if (model == null || model == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Model = model;
        }

        // String representation
        public override string ToString()
        {
            return $"Model: {this.Model}, " + base.ToString();
        }
    }
}
