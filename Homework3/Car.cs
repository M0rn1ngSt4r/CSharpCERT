using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Car
    {
        // Weight
        public double Weight { get; set; }
        // Height
        public double Height { get; set; }
        // On/Off
        public bool SwitchedOn { get; private set; }
        // Spare tire
        public bool SpareTire { get; private set; }
        // Headlights On/Off
        public bool HeadlightsOn { get; private set; }

        // Default constructor
        public Car()
        {
            this.Weight = 0;
            this.Height = 0;
            this.SwitchedOn = false;
            this.SpareTire = false;
            this.HeadlightsOn = false;
        }

        // Constructor with weight and height
        public Car(double weight, double height)
        {
            this.Weight = weight;
            this.Height = height;
            // Everything else to false
            this.SwitchedOn = false;
            this.SpareTire = false;
            this.HeadlightsOn = false;
        }

        // Car On
        public void SwitchOn()
        {
            this.SwitchedOn = true;
            this.Status();
        }

        // Car Off
        public void SwitchOff()
        {
            this.SwitchedOn = false;
            this.Status();
        }

        // Use spare tire, check if exists
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

        // Headlights On
        public void SwitchHeadlightsOn()
        {
            this.HeadlightsOn = true;
            Console.WriteLine("Headlights On!");
        }

        // Headlights Off
        public void SwitchHeadlightsOff()
        {
            this.HeadlightsOn = false;
            Console.WriteLine("Headlights Off...");
        }

        // Car Status
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

        // String representation, weight and height
        public override string ToString()
        {
            return $"Weight: {this.Weight} kg, Height: {this.Height} m";
        }
    }
}
