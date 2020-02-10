using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Car
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool SwitchedOn { get; private set; }
        public bool SpareTire { get; private set; }
        public bool HeadlightsOn { get; private set; }


        public Car()
        {
            this.Weight = 0;
            this.Height = 0;
            this.SwitchedOn = false;
            this.SpareTire = false;
            this.HeadlightsOn = false;
        }

        public Car(double weight, double height)
        {
            this.Weight = weight;
            this.Height = height;
            this.SwitchedOn = false;
            this.SpareTire = false;
            this.HeadlightsOn = false;
        }

        public void SwitchOn()
        {
            this.SwitchedOn = true;
            this.Status();
        }

        public void SwitchOff()
        {
            this.SwitchedOn = false;
            this.Status();
        }

        public void UseSpare()
        {
            if (this.SpareTire)
            {
                this.SpareTire = false;
                Console.WriteLine("Spare tire used!");
            }
            else
            {
                Console.WriteLine("No spare tire...");
            }
        }

        public void SwitchHeadlightsOn()
        {
            this.HeadlightsOn = true;
            Console.WriteLine("Headlights On!");
        }

        public void SwitchHeadlightsOff()
        {
            this.HeadlightsOn = false;
            Console.WriteLine("Headlights Off...");
        }

        public void Status()
        {
            if (this.SwitchedOn)
            {
                Console.WriteLine("Car is switched on!");
            }
            else
            {
                Console.WriteLine("Car is switched off...");
            }
        }

        public override string ToString()
        {
            return $"Weight: {this.Weight} kg, Height: {this.Height} m";
        }
    }
}
