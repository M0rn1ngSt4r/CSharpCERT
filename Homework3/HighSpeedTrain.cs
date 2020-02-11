using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    // Base class: Train
    class HighSpeedTrain : Train
    {
        // Maglev?
        public bool IsMaglev { get; set; }

        // No 'empty' HighSpeedTrain
        private HighSpeedTrain() { }

        // Constructor, all attributes
        public HighSpeedTrain(string model, double maxSpeed,
                              bool maglev) : base(model, maxSpeed)
        {
            this.IsMaglev = maglev;
        }

        // Reverse method, override
        public override void Reverse()
        {
            Console.WriteLine("Reversing immediately!");
        }

        // Advance method, override
        public override void Advance()
        {
            Console.WriteLine("Ffffffffffffffffffff");
        }

        // String representation
        public override string ToString()
        {
            return base.ToString() + $", Maglev: " +
                   $"{((this.IsMaglev) ? "Yes" : "No")}";
        }
    }
}
