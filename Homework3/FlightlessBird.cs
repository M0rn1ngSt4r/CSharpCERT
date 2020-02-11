using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    // Base Class: Bird
    class FlightlessBird : Bird
    {
        // Is domesticated bird
        public bool IsDomesticated { get; set; }

        // No 'empty' FlightlessBird
        private FlightlessBird() { }

        // Constructor, all atributes
        public FlightlessBird(string name, bool domesticated) : base(name)
        {
            this.IsDomesticated = domesticated;
        }

        // Override, no fly...
        public override void Fly()
        {
            throw new NotImplementedException();
        }

        // String representation
        public override string ToString()
        {
            return base.ToString() + " Cannot fly, Domesticated: " +
                   $"{((this.IsDomesticated) ? "Yes" : "No")}";
        }
    }
}
