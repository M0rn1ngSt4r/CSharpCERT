using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Bird
    {
        public string Species { get; private set; }

        protected Bird() { }


        public Bird(string name)
        {
            this.SetSpecies(name);
        }

        private void SetSpecies(string name)
        {
            if (name == null || name == string.Empty)
            {
                throw new ArgumentException();
            }
            this.Species = name;
        }

        public virtual void Fly()
        {
            Console.WriteLine("Fiuuuuuuuuuu");
        }

        public override string ToString()
        {
            return $"Species: {this.Species}, has wings.";
        }
    }
}
