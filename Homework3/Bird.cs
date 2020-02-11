using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Bird
    {
        // Species
        public string Species { get; private set; }

        // No 'empty' Bird
        protected Bird() { }

        // Constructor with species
        public Bird(string name)
        {
            this.SetSpecies(name);
        }

        // Validate Species, no null/empty values
        private void SetSpecies(string name)
        {
            if (name == null || name == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Species = name;
        }

        // Fly...
        public virtual void Fly()
        {
            Console.WriteLine("Fiuuuuuuuuuu");
        }

        // String representation
        public override string ToString()
        {
            return $"Species: {this.Species}, has wings.";
        }
    }
}
