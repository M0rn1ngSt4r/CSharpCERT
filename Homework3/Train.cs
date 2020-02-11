using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Train
    {
        // Model
        public string Model { get; private set; }
        // Max Speed
        public double MaxSpeed { get; private set; }

        // No 'empty' Train
        protected Train() { }

        // Constructor, all attributes
        public Train(string model, double maxSpeed)
        {
            this.SetModel(model);
            this.SetMaxSpeed(maxSpeed);
        }

        // Validate model, no null/empty values
        private void SetModel(string model)
        {
            if (model == null || model == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Model = model;
        }

        // Validate speed, no negative/zero values
        private void SetMaxSpeed(double maxSpeed)
        {
            if (maxSpeed <= 0)
            {
                throw new ArgumentException();
            }
            this.MaxSpeed = maxSpeed;
        }

        // Advance method
        public virtual void Advance()
        {
            Console.WriteLine("Chuchuuuuuuuuuu");
        }

        // Reverse method, not implemented
        public virtual void Reverse()
        {
            throw new NotImplementedException();
        }

        // String representation
        public override string ToString()
        {
            return $"Model: {this.Model}, Max Speed: {this.MaxSpeed} km/h";
        }
    }
}
