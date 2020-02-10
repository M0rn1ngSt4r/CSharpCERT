using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class SteamLocomotive : Train
    {
        public double FuelCargo { get; private set; }
        public string FuelType { get; private set; }

        private SteamLocomotive() { }

        public SteamLocomotive(string model, double maxSpeed,
                               string fuelType,
                               double fuelCargo) : base(model, maxSpeed)
        {
            this.SetFuelCargo(fuelCargo);
            this.SetFuelType(fuelType);
        }

        private void SetFuelType(string fuelType)
        {
            if (fuelType == null || fuelType == string.Empty)
            {
                throw new ArgumentException();
            }
            this.FuelType = fuelType;
        }

        private void SetFuelCargo(double fuelCargo)
        {
            if (fuelCargo <= 0)
            {
                throw new ArgumentException();
            }
            this.FuelCargo = fuelCargo;
        }

        public override void Reverse()
        {
            Console.WriteLine("Reversing gear on!");
        }

        public override string ToString()
        {
            return base.ToString() + $", Fuel type: {this.FuelType} " +
                   $"(Current: {this.FuelCargo} kg)";
        }
    }
}
