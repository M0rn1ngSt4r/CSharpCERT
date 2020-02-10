using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        private Product() { }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static Product Create()
        {
            double value = -1;
            string name = string.Empty;
            do
            {
                Console.Write("Product name: ");
                name = Console.ReadLine();
            } while (name == string.Empty);
            do
            {
                try
                {
                    Console.Write("Product value: $");
                    value = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid price...");
                    value = -1;
                }
            } while (value < 0);
            return new Product(name, value);
        }

        public override string ToString()
        {
            return $"Product: {this.Name} - Price: ${this.Price:0.00}";
        }
    }
}
