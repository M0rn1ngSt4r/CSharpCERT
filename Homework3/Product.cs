using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Product
    {
        // Name
        public string Name { get; set; }
        // Price
        public double Price { get; set; }

        // No 'empty' product
        private Product() { }

        // Constructor with name and price
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static Product Create()
        {
            // Create product
            double value = -1;
            string name = string.Empty;
            do
            {
                // No 'empty' name
                Console.Write("Product name: ");
                name = Console.ReadLine();
            } while (name == string.Empty);
            // Loop for valid price, positive number
            do
            {
                try
                {
                    // User input
                    Console.Write("Product value: $");
                    value = Convert.ToDouble(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    Console.WriteLine("Invalid price...");
                    value = -1;
                }
            } while (value < 0);
            return new Product(name, value);
        }

        // String representation
        public override string ToString()
        {
            return $"Product: {this.Name} - Price: ${this.Price:0.00}";
        }
    }
}
