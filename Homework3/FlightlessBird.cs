using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class FlightlessBird : Bird
    {
        public bool IsDomesticated { get; set; }

        private FlightlessBird() { }

        public FlightlessBird(string name, bool domesticated) : base(name)
        {
            this.IsDomesticated = domesticated;
        }

        public override void Fly()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + " Cannot fly, Domesticated: " +
                   $"{((this.IsDomesticated) ? "Yes" : "No")}";
        }
    }
}
