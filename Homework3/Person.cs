using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Person
    {
        // Name
        public string Name { get; set; }
        // Age
        public int Age { get; set; }
        // Height (m)
        public double Height { get; set; }
        // Weight (kg)
        public double Weight { get; set; }

        // No 'empty' person
        private Person() { }

        // Constructor with name, age, height and weight
        public Person(string name, int age, double height, double weight)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Weight = weight;
        }

        // Guess gender
        public static void GuessGender(Person person)
        {
            // Last character of name is 'o', maybe is a male
            if (person.Name[person.Name.Length - 1] == 'o')
            {
                Console.WriteLine("Maybe Male...");
            }
            // Last character of name is a, maybe is female
            else if (person.Name[person.Name.Length - 1] == 'a')
            {
                Console.WriteLine("Maybe Female...");
            }
            // Who knows...
            else
            {
                Console.WriteLine("Maybe Attack Helicopter...");
            }
        }

        // Short if height is less than 1.5 m
        public bool IsShort()
        {
            return (this.Height < 1.5);
        }

        // Old if age is 60+
        public bool IsOld()
        {
            return (this.Age > 59);
        }

        // String representation, all attributes
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Height: " +
                   $"{this.Height}, Weight: {this.Weight}";
        }
    }
}
