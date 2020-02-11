using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    // Base class: Train
    class SteamLocomotive : Train
    {
        // Fuel quantity
        public double FuelCargo { get; private set; }
        // Type of fuel
        public string FuelType { get; private set; }

        // No 'empty' SteamLocomotive
        private SteamLocomotive() { }

        // Constructor, all attributes
        public SteamLocomotive(string model, double maxSpeed,
                               string fuelType,
                               double fuelCargo) : base(model, maxSpeed)
        {
            this.SetFuelCargo(fuelCargo);
            this.SetFuelType(fuelType);
        }

        // Validate fuel type, no null/empty values
        private void SetFuelType(string fuelType)
        {
            if (fuelType == null || fuelType == string.Empty)
            {
                throw new ArgumentException();
            }
            this.FuelType = fuelType;
        }

        // Validate fuel cargo, no negative values
        private void SetFuelCargo(double fuelCargo)
        {
            if (fuelCargo <= 0)
            {
                throw new ArgumentException();
            }
            this.FuelCargo = fuelCargo;
        }

        // Reverse method, override
        public override void Reverse()
        {
            Console.WriteLine("Reversing gear on!");
        }

        // String representation
        public override string ToString()
        {
            return base.ToString() + $", Fuel type: {this.FuelType} " +
                   $"(Current: {this.FuelCargo} kg)";
        }
    }
}
