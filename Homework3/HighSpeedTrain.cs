using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class HighSpeedTrain : Train
    {
        public bool IsMaglev { get; set; }

        private HighSpeedTrain() { }

        public HighSpeedTrain(string model, double maxSpeed,
                              bool maglev) : base(model, maxSpeed)
        {
            this.IsMaglev = maglev;
        }

        public override void Reverse()
        {
            Console.WriteLine("Reversing immediately!");
        }

        public override void Advance()
        {
            Console.WriteLine("Ffffffffffffffffffff");
        }

        public override string ToString()
        {
            return base.ToString() + $", Maglev: " +
                   $"{((this.IsMaglev) ? "Yes" : "No")}";
        }
    }
}
