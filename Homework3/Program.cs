using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework3
{
    class Program
    {
        /*
         * Exercise 1
         * ********************************************************************
         */
        static int NSum(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }
            // Sum of first n numbers by Gauss.
            return n * (n + 1) / 2;
        }

        static void Exercise1()
        {
            int n;
            try
            {
                Console.Write("Enter natural number: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Sum of first {n} natural numbers is: " +
                                  $"{NSum(n)}");
            }
            // Failed "cast" to int
            catch (FormatException)
            {
                Console.WriteLine("Not a number...");
            }
            // Negative number
            catch (ArgumentException)
            {
                Console.WriteLine("Not a natural number...");
            }
        }
        // ********************************************************************

        /*
         * Exercise 2
         * ********************************************************************
         */
        static void ClapNumber(int n1, int n2)
        {
            // Numbers are less than one or greater than 9, fail...
            if (n1 < 1 || n1 > 9 || n2 < 1 || n2 > 9)
            {
                throw new ArgumentException();
            }
            // Numbers converted to string
            string str1 = n1.ToString();
            string str2 = n2.ToString();
            for (int i = 1; i <= 100; i++)
            {
                // Current number to string
                string aux = i.ToString();
                // Digits are in current number, or multiple, print 'clap'
                if (aux.Contains(str1) || aux.Contains(str2) || i % n1 == 0 ||
                    i % n2 == 0)
                {
                    Console.WriteLine("clap");
                }
                // Print normal number
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Exercise2()
        {
            int n1;
            int n2;
            try
            {
                // User input
                Console.Write("Enter first number: ");
                n1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number: ");
                n2 = Convert.ToInt32(Console.ReadLine());
                // Function clap
                ClapNumber(n1, n2);
            }
            // Failed cast string to int
            catch (FormatException)
            {
                Console.WriteLine("Not a number...");
                return;
            }
            // Not single digits
            catch (ArgumentException)
            {
                Console.WriteLine("Numbers not in range [1, 9], try again...");
            }
        }
        // ********************************************************************

        /*
         * Exercise 3
         * ********************************************************************
         */
        static string AddF(string data)
        {
            // String builder, faster than concat
            StringBuilder builder = new StringBuilder();
            // Vowels
            string vowels = "aeiou";
            // Iterate string
            for (int i = 0; i < data.Length; i++)
            {
                // Character is a vowel, add 'f'
                if (vowels.Contains(Char.ToLower(data[i])))
                {
                    builder.Append('f');
                }
                // Append original character
                builder.Append(data[i]);
            }
            return builder.ToString();
        }

        static void Exercise3()
        {
            // User input
            Console.Write("Enter string: ");
            string data = Console.ReadLine();
            // Function call
            Console.WriteLine($"New String: {AddF(data)}");
        }
        // ********************************************************************

        /*
         * Exercise 4
         * ********************************************************************
         */
        static void FibonacciSeries(int n)
        {
            // No negative index
            if (n < 0)
            {
                return;
            }
            // Formula works for cases greater than 1
            if (n >= 0)
            {
                Console.WriteLine("0");
            }
            if (n >= 1)
            {
                Console.WriteLine("1");
            }
            /* 
             * Using formula described here:
             * http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html#section4
             */
            long i = 1;
            while (n > 1)
            {
                Console.WriteLine(i);
                try
                {
                    i = Convert.ToInt64(Math.Round(i * ((1 + Math.Sqrt(5)) / 2)));
                }
                // Large number
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large now, aborting...");
                    break;
                }
                n--;
            }
        }

        static void Exercise4()
        {
            int n;
            try
            {
                // User input
                Console.Write("Enter index number: ");
                n = Convert.ToInt32(Console.ReadLine());
                FibonacciSeries(n);
            }
            // Failed cast string to int
            catch (FormatException)
            {
                Console.WriteLine("Not a number...");
                return;
            }
        }
        // ********************************************************************

        /*
         * Exercise 5
         * ********************************************************************
         */

        static void Exercise5()
        {
            // Dictionary
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            int option = 0;
            // Submenu
            while (option != 4)
            {
                Console.WriteLine("\nPHONEBOOK\n");
                // Print phonebook
                foreach (KeyValuePair<string, string> entry in phonebook)
                {
                    Console.WriteLine($"Name: {entry.Key}");
                    Console.WriteLine($"Number: {entry.Value}\n");
                }
                Console.WriteLine("1. Add contact.");
                Console.WriteLine("2. Delete contact.");
                Console.WriteLine("3. Modify contact.");
                Console.WriteLine("4. Exit.");
                Console.Write("Your option: ");
                // User option
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                string contact = "";
                string number = "";
                // Contact name (input)
                if (option > 0 && option < 4)
                {
                    Console.Write("Contact name: ");
                    contact = Console.ReadLine();
                }
                // Contact number (input, format 8 numbers)
                if (option == 1 || option == 3)
                {
                    Regex regex = new Regex(@"^\d{10}$");
                    do
                    {
                        Console.Write("Contact number (10 numbers format): ");
                        number = Console.ReadLine();
                    } while (!regex.IsMatch(number));
                }
                switch (option)
                {
                    // Add contact
                    case 1:
                        try
                        {
                            phonebook.Add(contact, number);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Contact already exists...");
                        }
                        break;
                    // Remove contact
                    case 2:
                        if (!phonebook.Remove(contact))
                        {
                            Console.WriteLine("Contact does not exist...");
                        }
                        else
                        {
                            Console.WriteLine("Contact has been deleted.");
                        }
                        break;
                    // Modify entry
                    case 3:
                        try
                        {
                            // Need to check if it exists, otherwise is created
                            if (!phonebook.ContainsKey(contact))
                            {
                                throw new KeyNotFoundException();
                            }
                            phonebook[contact] = number;
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Contact does not exist...");
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        break;
                }
            }
        }
        // ********************************************************************

        /*
         * Exercise 6
         * ********************************************************************
         */
        static void Exercise6()
        {
            // 'Normal' instance of BankAccount
            BankAccount ba1 = new BankAccount("Fulanito1", 10000.50);
            // Instance with negative balance (set to zero by class)
            BankAccount ba2 = new BankAccount("Fulanito2", -10.99);
            Console.WriteLine("Adding $99.99 to Fulanito1...");
            // Adding money
            ba1.AddMoney(99.99);
            Console.WriteLine("Withdrawing $50000 from Fulanito1...");
            // Withdrawing money, more than current balance
            ba1.MakeWithdraw(50000);
            Console.WriteLine("Adding $9999.99 to Fulanito2...");
            // Adding money
            ba2.AddMoney(9999.99);
            Console.WriteLine("Withdrawing $0.99 from Fulanito2...");
            // 'Normal' withdrawal
            ba2.MakeWithdraw(0.99);
        }
        // ********************************************************************

        /*
         * Exercise 7
         * ********************************************************************
         */
        static void Exercise7()
        {
            // Instances of complex number, divided in 2 parts
            ComplexNumber cn1 = new ComplexNumber(-23.56, 0);
            ComplexNumber cn2 = new ComplexNumber(45.5, -0.5);
            // ToString method
            Console.WriteLine($"First complex number: {cn1}");
            Console.WriteLine($"First complex number: {cn2}");
            // Static method to Add, part by part
            Console.WriteLine($"({cn1}) + ({cn2}): " +
                              $"{ComplexNumber.Add(cn1, cn2)}");
        }
        // ********************************************************************

        /*
         * Exercise 8
         * ********************************************************************
         */
        static void Exercise8()
        {
            // 3 instances of Car class
            Car c1 = new Car();
            Car c2 = new Car(840, 1.5);
            Car c3 = new Car(2005, 1.2);
            // No ToString in this exercise, printing all 3
            Console.WriteLine($"\nWeight: {c1.Weight} kg");
            Console.WriteLine($"Height: {c1.Height} m");
            // Status method
            c1.Status();
            Console.WriteLine($"\nWeight: {c2.Weight} kg");
            Console.WriteLine($"Height: {c2.Height} m");
            c2.Status();
            Console.WriteLine($"\nWeight: {c3.Weight} kg");
            Console.WriteLine($"Height: {c3.Height} m");
            c3.Status();
            // Changing properties
            Console.WriteLine("\nChanging first car...");
            c1.Weight = 1385;
            c1.Height = 1.03;
            // Showing changes
            Console.WriteLine($"\nWeight: {c1.Weight} kg");
            Console.WriteLine($"Height: {c1.Height} m");
            // Switch on car
            c1.SwitchOn();
            Console.WriteLine("\nChanging second car...");
            c2.Weight = 800.1;
            Console.WriteLine($"\nWeight: {c2.Weight} kg");
            Console.WriteLine($"Height: {c2.Height} m");
            // Switch headlight on
            c1.SwitchHeadlightsOn();
            Console.WriteLine("\nChanging third car...");
            Console.WriteLine($"\nWeight: {c3.Weight} kg");
            Console.WriteLine($"Height: {c3.Height} m");
            // All 3 extra methods in use
            c3.SwitchOn();
            c3.SwitchHeadlightsOn();
            c3.UseSpare();
        }
        // ********************************************************************

        /*
         * Exercise 9
         * ********************************************************************
         */
        static void Exercise9()
        {
            // Circle with radius in constructor
            Circle c1 = new Circle(6);
            // Equilateral Triangle with side in constructor
            EquilateralTriangle et1 = new EquilateralTriangle(10);
            // Print radius length
            Console.WriteLine($"Circle with a radius of {c1.Radius}");
            // Print area of circle
            Console.WriteLine($"Area: {c1.GetArea()}");
            // Print side length of triangle container
            Console.WriteLine("Side of posible equilateral triangle " +
                              $"container: {c1.GetTriangleContainer().Side}");
            // Print side length
            Console.WriteLine($"\nEquilateral Triangle with a side of " +
                              $"{et1.Side}");
            // Print height of triangle
            Console.WriteLine($"Height: {et1.GetHeight()}");
            // Print area of triangle
            Console.WriteLine($"Area: {et1.GetArea()}");
            // Print circumcircle radius
            Console.WriteLine("Radius of circumcircle : " +
                              $"{et1.GetCircleContainer().Radius}");
        }
        // ********************************************************************

        /*
         * Exercise 10
         * ********************************************************************
         */
        static void Exercise10()
        {
            // 2 instances of person
            Person p1 = new Person("Ana", 24, 1.48, 45);
            Person p2 = new Person("Guadalupe", 60, 1.89, 95.9);
            Console.WriteLine(p1);
            // Guessing gender of person
            Person.GuessGender(p1);
            // Person is short?
            Console.WriteLine($"Is Short: {p1.IsShort()}");
            // Person is Old
            Console.WriteLine($"Is Old: {p1.IsOld()}\n");
            // Analog for person number 2
            Console.WriteLine(p2);
            Person.GuessGender(p2);
            Console.WriteLine($"Is Short: {p2.IsShort()}");
            Console.WriteLine($"Is Old: {p2.IsOld()}");
        }
        // ********************************************************************

        /*
         * Exercise 11
         * ********************************************************************
         */
        static void Exercise11()
        {
            // 2 Matrix instances
            Matrix m1 = new Matrix(1);
            Matrix m2 = new Matrix(1);
            int option = 0;
            // Submenu
            while (option != 6)
            {
                Console.WriteLine("\nMATRIX CALCULATOR\n");
                Console.WriteLine($"Matrix 1:\n{m1}");
                Console.WriteLine($"\nMatrix 2:\n{m2}");
                Console.WriteLine("1. Set First matrix.");
                Console.WriteLine("2. Set Second matrix.");
                Console.WriteLine("3. Addition.");
                Console.WriteLine("4. Subtraction.");
                Console.WriteLine("5. Multiplication.");
                Console.WriteLine("6. Exit.");
                Console.Write("Your option: ");
                try
                {
                    // User option
                    option = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        // Static method, initialize matrix 1
                        m1 = Matrix.InitializeMatrix();
                        break;
                    case 2:
                        // Static method, initialize matrix 2
                        m2 = Matrix.InitializeMatrix();
                        break;
                    case 3:
                        try
                        {
                            // Addition of matrixes
                            Console.WriteLine($"Addition:\n{Matrix.Addition(m1, m2)}");
                        }
                        // Matrix dimension not the same
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Incompatible matrices...");
                        }
                        break;
                    case 4:
                        try
                        {
                            // Subtraction of matrixes
                            Console.WriteLine($"Subtraction:\n{Matrix.Subtraction(m1, m2)}");
                        }
                        // Matrix dimension not the same
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Incompatible matrices...");
                        }
                        break;
                    case 5:
                        try
                        {
                            // Multiplication of matrixes
                            Console.WriteLine($"Multiplication:\n{Matrix.Multiplication(m1, m2)}");
                        }
                        // Matrix dimension not the same
                        catch (ArgumentException)
                        {

                            Console.WriteLine("Incompatible matrices...");
                        }
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        break;
                }
            }
        }
        // ********************************************************************

        /*
         * Exercise 12
         * ********************************************************************
         */
        static void Exercise12()
        {
            // List of products, instead of 2
            List<Product> shoppingList = new List<Product>();
            int option = 0;
            int i;
            double total;
            // Submenu
            while (option != 4)
            {
                total = 0;
                Console.WriteLine("\nSHOPPING LIST\n");
                // Print shopping list
                for (i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                    total += shoppingList[i].Price;
                }
                // Print current total
                Console.WriteLine($"\nTotal: {total:0.00}");
                Console.WriteLine("\nBECARIO MART\n");
                Console.WriteLine("1. Add product.");
                Console.WriteLine("2. Remove product.");
                Console.WriteLine("3. Pay.");
                Console.WriteLine("4. Exit.");
                Console.Write("Your option: ");
                try
                {
                    // User option
                    option = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        // Add new product (Create method)
                        shoppingList.Add(Product.Create());
                        break;
                    case 2:
                        // Remove product, if list is not empty
                        if (shoppingList.Count == 0)
                        {
                            Console.WriteLine("Shopping list is empty...");
                            continue;
                        }
                        int index;
                        try
                        {
                            // User input, list element
                            index = Convert.ToInt32(Console.ReadLine());
                        }
                        // Failed cast string to int
                        catch (FormatException)
                        {
                            Console.WriteLine("Only numbers, try again...");
                            continue;
                        }
                        // Validate index in not out of bounds
                        if (index <= 0 || index > shoppingList.Count)
                        {
                            Console.WriteLine("Index out of bounds...");
                            continue;
                        }
                        // Remove item at specified position
                        shoppingList.RemoveAt(index - 1);
                        break;
                    case 3:
                        // If current total is less or equal to 500, pay
                        if (total <= 500)
                        {
                            Console.WriteLine("THANKS FOR YOUR PURCHASE!");
                            shoppingList.Clear();
                        }
                        // Notify and continue
                        else
                        {
                            Console.WriteLine("LIMIT EXCEEDED, REMOVE ITEMS...");
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        break;
                }
            }
        }
        // ********************************************************************

        /*
         * Exercise 13
         * ********************************************************************
         */
        static void Exercise13()
        {
            try
            {
                // Vintage car object
                VintageCar vc = new VintageCar("Thunderbird", 2005, 1.2);
                // With turbo
                vc.Turbo = true;
                // Sports car object
                SportsCar sc = new SportsCar("P1", 1547, 1.188);
                // Hybrid
                sc.IsHybrid = true;
                // Print vintage car
                Console.WriteLine(vc);
                // Inherited method from Car class
                vc.Status();
                // Turbo information
                Console.WriteLine($"Turbo: {((vc.Turbo) ? "Yes" : "No")}");
                // Inherited method from Car class
                vc.SwitchOn();
                // Print sports car
                Console.WriteLine($"\n{sc}");
                // Inherited methods from Car class
                sc.Status();
                sc.SwitchHeadlightsOn();
                sc.UseSpare();
            }
            // Models are not valid
            catch (ArgumentException)
            {
                Console.WriteLine("Null/Empty models are not allowed...");
            }
        }
        // ********************************************************************

        /*
         * Exercise 14
         * ********************************************************************
         */
        static void Exercise14()
        {
            // Objects using interface IClock
            IClock c1 = new SolarClock();
            IClock c2 = new AnalogClock();
            IClock c3 = new DigitalClock();
            Console.WriteLine("\nSolar clock:");
            // Using GetTime method from interface IClock
            Console.WriteLine($"Time (Only hour available): {c1.GetTime()}");
            Console.Write("Alarm tune: ");
            // Using SoundAlarm method form interface IClock
            c1.SoundAlarm();
            Console.WriteLine("\nAnalog clock:");
            Console.WriteLine("Time (Only hour and minutes available): " +
                              $"{c2.GetTime()}");
            Console.Write("Alarm tune: ");
            c2.SoundAlarm();
            Console.WriteLine("\nDigital clock:");
            Console.WriteLine($"Time and date: {c3.GetTime()}");
            Console.Write("Alarm tune: ");
            c3.SoundAlarm();
        }
        // ********************************************************************

        /*
         * Exercise 15
         * ********************************************************************
         */
        static void Exercise15()
        {
            double n1 = 0;
            double n2 = 0;
            int option = 0;
            // Submenu
            while (option != 7)
            {
                Console.WriteLine("\nCALCULATOR\n");
                Console.WriteLine($"Number 1:\n{n1}");
                Console.WriteLine($"\nNumber 2:\n{n2}\n");
                Console.WriteLine("1. Set First Number.");
                Console.WriteLine("2. Set Second Number.");
                Console.WriteLine("3. Addition.");
                Console.WriteLine("4. Subtraction.");
                Console.WriteLine("5. Multiplication.");
                Console.WriteLine("6. Division.");
                Console.WriteLine("7. Exit.");
                Console.Write("Your option: ");
                try
                {
                    // User option
                    option = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        try
                        {
                            // Number 1, input
                            n1 = Convert.ToDouble(Console.ReadLine());
                        }
                        // Failed cast string to int
                        catch (FormatException)
                        {
                            n1 = 0;
                            Console.WriteLine("Only numbers...");
                        }
                        // Number too large
                        catch (OverflowException)
                        {
                            n1 = 0;
                            Console.WriteLine("Number is too large...");
                        }
                        break;
                    case 2:
                        // Analog from case 1, for number 2
                        try
                        {
                            n2 = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            n2 = 0;
                            Console.WriteLine("Only numbers...");
                        }
                        catch (OverflowException)
                        {
                            n2 = 0;
                            Console.WriteLine("Number is too large...");
                        }
                        break;
                    case 3:
                        // Addition
                        try
                        {
                            Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
                        }
                        // Result too large
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 4:
                        // Subtraction
                        try
                        {
                            Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
                        }
                        // Result too large?
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 5:
                        // Multiplication
                        try
                        {
                            Console.WriteLine($"{n1} X {n2} = {n1 * n2}");
                        }
                        // Result too large
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 6:
                        // Division
                        try
                        {
                            // Division by zero?
                            if (n2 == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            // Print result
                            Console.WriteLine($"{n1} / {n2} = {n1 / n2}");
                        } // Result too large?
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        // Division by zero, notification 
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Division by zero is not defined...");
                        }
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        break;
                }
            }
        }
        // ********************************************************************

        /*
         * Exercise 16
         * ********************************************************************
         */
        static void Exercise16()
        {
            // Bird objects, 1 is FlightlessBird
            Bird b1 = new Bird("Canary");
            Bird b2 = new FlightlessBird("Dodo", false);
            // Use fly methods
            Console.WriteLine($"\n{b1}");
            b1.Fly();
            Console.WriteLine($"\n{b2}");
            // Flightles bird cannot fly
            try
            {
                b2.Fly();
            }
            // b2 cant fly, not implemented
            catch (NotImplementedException)
            {
                Console.WriteLine("NotImplementedException (cannot fly)");
            }
        }
        // ********************************************************************

        /*
         * Exercise 17
         * ********************************************************************
         */
        static void Exercise17()
        {
            // List of trains
            List<Train> trains = new List<Train>();
            Random rnd = new Random();
            // Fill list with 10 random trians
            for (int i = 0; i < 10; i++)
            {
                // 0 - Default train
                int type = rnd.Next(0, 3);
                if (type == 0)
                {
                    trains.Add(new Train("Basic Train", 50));
                }
                // 1 - Steam train
                else if (type == 1)
                {
                    trains.Add(new SteamLocomotive("Steam Train", 120, "Coal",
                                                   1000.5));
                }
                // 2 - Highspeed train
                else
                {
                    trains.Add(new HighSpeedTrain("Magnetic Train", 590, true));
                }
            }
            // Each train uses methods from Train class, dynamic polymorphism
            foreach (Train t in trains)
            {
                Console.WriteLine($"\n{t}");
                t.Advance();
                // Default trains cannot go in reverse
                try
                {
                    t.Reverse();
                }
                // Default train has no reverse implemented
                catch (NotImplementedException)
                {
                    Console.WriteLine("Cannot go in reverse...");
                }
            }
        }
        // ********************************************************************

        /*
         * Exercise 18
         * ********************************************************************
         */
        static void Exercise18()
        {
            // File name
            string fileName;
            // Data to write
            string data;
            // Get a valid file name
            do
            {
                Console.Write("Insert file name: ");
                fileName = Console.ReadLine();
            } while (fileName == string.Empty);
            // Get something to write
            do
            {
                Console.WriteLine("Insert data to append to file:");
                data = Console.ReadLine();
            } while (data == string.Empty);
            // Get usable folder/path
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = Path.Combine(path, "RMRHomework3");
            // If path does not exist, create it...
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Creating directory: {path}");
                Directory.CreateDirectory(path);
            }
            Console.WriteLine($"Writing to {Path.Combine(path, fileName)}");
            // Append text to file, and close it
            File.AppendAllText(Path.Combine(path, fileName), data);
            Console.WriteLine("Done!");
        }
        // ********************************************************************

        static void Main(string[] args)
        {
            int option = 0;
            // Main Menu
            while (option != 19)
            {
                Console.WriteLine("\n1. Sum of first N Natural Numbers");
                Console.WriteLine("2. Clap numbers.");
                Console.WriteLine("3. Add 'f'.");
                Console.WriteLine("4. Fibonacci.");
                Console.WriteLine("5. Phonebook.");
                Console.WriteLine("6. Bank Account.");
                Console.WriteLine("7. Complex Number");
                Console.WriteLine("8. Car class 1.");
                Console.WriteLine("9. Shapes.");
                Console.WriteLine("10. Person class.");
                Console.WriteLine("11. Matrix Calculator.");
                Console.WriteLine("12. BecarioMart.");
                Console.WriteLine("13. Car class 2 (Inheritance).");
                Console.WriteLine("14. Interface.");
                Console.WriteLine("15. Number Calculator");
                Console.WriteLine("16. Polymorphism.");
                Console.WriteLine("17. OOP");
                Console.WriteLine("18. File Operations.");
                Console.WriteLine("19. Exit.");
                Console.Write("Your option: ");
                try
                {
                    // User option
                    option = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                    case 11:
                        Exercise11();
                        break;
                    case 12:
                        Exercise12();
                        break;
                    case 13:
                        Exercise13();
                        break;
                    case 14:
                        Exercise14();
                        break;
                    case 15:
                        Exercise15();
                        break;
                    case 16:
                        Exercise16();
                        break;
                    case 17:
                        Exercise17();
                        break;
                    case 18:
                        Exercise18();
                        break;
                    case 19:
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        break;
                }
            }
        }
    }
}
