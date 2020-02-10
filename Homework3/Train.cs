using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Train
    {
        public string Model { get; private set; }
        public double MaxSpeed { get; private set; }

        protected Train() { }

        public Train(string model, double maxSpeed)
        {
            this.SetModel(model);
            this.SetMaxSpeed(maxSpeed);
        }

        private void SetModel(string model)
        {
            if (model == null || model == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Model = model;
        }

        private void SetMaxSpeed(double maxSpeed)
        {
            if (maxSpeed <= 0)
            {
                throw new ArgumentException();
            }
            this.MaxSpeed = maxSpeed;
        }

        public virtual void Advance()
        {
            Console.WriteLine("Chuchuuuuuuuuuu");
        }

        public virtual void Reverse()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Model: {this.Model}, Max Speed: {this.MaxSpeed} km/h";
        }
    }
}
