using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        private Person() { }

        public Person(string name, int age, double height, double weight)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Weight = weight;
        }

        public static void GuessGender(Person person)
        {
            if (person.Name[person.Name.Length - 1] == 'o')
            {
                Console.WriteLine("Maybe Male...");
            }
            else if (person.Name[person.Name.Length - 1] == 'a')
            {
                Console.WriteLine("Maybe Female...");
            }
            else
            {
                Console.WriteLine("Maybe Attack Helicopter...");
            }
        }

        public bool IsShort()
        {
            return (this.Height < 1.5);
        }

        public bool IsOld()
        {
            return (this.Age > 59);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Height: " +
                   $"{this.Height}, Weight: {this.Weight}";
        }
    }
}
