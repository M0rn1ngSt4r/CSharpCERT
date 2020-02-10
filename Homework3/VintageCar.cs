using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class VintageCar : Car
    {
        public string Model { get; private set; }
        public bool Turbo { get; set; }

        protected VintageCar() { }

        public VintageCar(string model, double weight,
                          double height) : base(weight, height)
        {
            this.SetModel(model);
            this.Turbo = false;
        }

        public void SetModel(string model)
        {
            if (model == null || model == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Model = model;
        }

        public override string ToString()
        {
            return $"Model: {this.Model}, " + base.ToString();
        }
    }
}
