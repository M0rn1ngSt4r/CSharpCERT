﻿using System;
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
            catch (FormatException)
            {
                Console.WriteLine("Not a number...");
                return;
            }
        }
        // ********************************************************************

        /*
         * Exercise 2
         * ********************************************************************
         */
        static void ClapNumber(int n1, int n2)
        {
            if (n1 < 1 || n1 > 9 || n2 < 1 || n2 > 9)
            {
                throw new ArgumentException();
            }
            string str1 = n1.ToString();
            string str2 = n2.ToString();
            for (int i = 1; i <= 100; i++)
            {
                string aux = i.ToString();
                // Check if digits are in current number, or multiple.
                if (aux.Contains(str1) || aux.Contains(str2) || i % n1 == 0 ||
                    i % n2 == 0)
                {
                    Console.WriteLine("clap");
                }
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
                Console.Write("Enter first number: ");
                n1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number: ");
                n2 = Convert.ToInt32(Console.ReadLine());
                ClapNumber(n1, n2);
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number...");
                return;
            }
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
            StringBuilder builder = new StringBuilder();
            string vocals = "aeiou";
            for (int i = 0; i < data.Length; i++)
            {
                if (vocals.Contains(Char.ToLower(data[i])))
                {
                    builder.Append('f');
                }
                builder.Append(data[i]);
            }
            return builder.ToString();
        }

        static void Exercise3()
        {
            Console.Write("Enter string: ");
            string data = Console.ReadLine();
            Console.WriteLine($"New String: {AddF(data)}");
        }
        // ********************************************************************

        /*
         * Exercise 4
         * ********************************************************************
         */
        static void FibonacciSeries(int n)
        {
            if (n < 0)
            {
                return;
            }
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
                Console.Write("Enter index number: ");
                n = Convert.ToInt32(Console.ReadLine());
                FibonacciSeries(n);
            }
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
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            int option = 0;
            while (option != 4)
            {
                Console.WriteLine("\nPHONEBOOK\n");
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
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                string contact = "";
                string number = "";
                if (option > 0 && option < 4)
                {
                    Console.Write("Contact name: ");
                    contact = Console.ReadLine();
                }
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
                    case 3:
                        try
                        {
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
            BankAccount ba1 = new BankAccount("Fulanito1", 10000.50);
            BankAccount ba2 = new BankAccount("Fulanito2", -10.99);
            Console.WriteLine("Adding $99.99 to Fulanito1...");
            ba1.AddMoney(99.99);
            Console.WriteLine("Withdrawing $50000 from Fulanito1...");
            ba1.MakeWithdraw(50000);
            Console.WriteLine("Adding $9999.99 to Fulanito2...");
            ba2.AddMoney(9999.99);
            Console.WriteLine("Withdrawing $0.99 from Fulanito2...");
            ba2.MakeWithdraw(0.99);
        }
        // ********************************************************************

        /*
         * Exercise 7
         * ********************************************************************
         */
        static void Exercise7()
        {
            ComplexNumber cn1 = new ComplexNumber(-23.56, 0);
            ComplexNumber cn2 = new ComplexNumber(45.5, -0.5);
            Console.WriteLine($"First complex number: {cn1}");
            Console.WriteLine($"First complex number: {cn2}");
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
            Car c1 = new Car();
            Car c2 = new Car(840, 1.5);
            Car c3 = new Car(2005, 1.2);
            Console.WriteLine($"\nWeight: {c1.Weight} kg");
            Console.WriteLine($"Height: {c1.Height} m");
            c1.Status();
            Console.WriteLine($"\nWeight: {c2.Weight} kg");
            Console.WriteLine($"Height: {c2.Height} m");
            c2.Status();
            Console.WriteLine($"\nWeight: {c3.Weight} kg");
            Console.WriteLine($"Height: {c3.Height} m");
            c3.Status();
            Console.WriteLine("\nChanging first car...");
            c1.Weight = 1385;
            c1.Height = 1.03;
            Console.WriteLine($"\nWeight: {c1.Weight} kg");
            Console.WriteLine($"Height: {c1.Height} m");
            c1.SwitchOn();
            Console.WriteLine("\nChanging second car...");
            c2.Weight = 800.1;
            Console.WriteLine($"\nWeight: {c2.Weight} kg");
            Console.WriteLine($"Height: {c2.Height} m");
            c1.SwitchHeadlightsOn();
            Console.WriteLine("\nChanging third car...");
            Console.WriteLine($"\nWeight: {c3.Weight} kg");
            Console.WriteLine($"Height: {c3.Height} m");
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
            Circle c1 = new Circle(6);
            EquilateralTriangle et1 = new EquilateralTriangle(10);
            Console.WriteLine($"Circle with a radius of {c1.Radius}");
            Console.WriteLine($"Area: {c1.GetArea()}");
            Console.WriteLine("Side of posible equilateral triangle " +
                              $"container: {c1.GetTriangleContainer().Side}");
            Console.WriteLine($"\nEquilateral Triangle with a side of " +
                              $"{et1.Side}");
            Console.WriteLine($"Height: {et1.GetHeight()}");
            Console.WriteLine($"Area: {et1.GetArea()}");
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
            Person p1 = new Person("Ana", 24, 1.48, 45);
            Person p2 = new Person("Guadalupe", 60, 1.89, 95.9);
            Console.WriteLine(p1);
            Person.GuessGender(p1);
            Console.WriteLine($"Is Short: {p1.IsShort()}");
            Console.WriteLine($"Is Old: {p1.IsOld()}\n");
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
            Matrix m1 = new Matrix(1);
            Matrix m2 = new Matrix(1);
            int option = 0;
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
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        m1 = Matrix.InitializeMatrix();
                        break;
                    case 2:
                        m2 = Matrix.InitializeMatrix();
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine($"Addition:\n{Matrix.Addition(m1, m2)}");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Incompatible matrices...");
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine($"Subtraction:\n{Matrix.Subtraction(m1, m2)}");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Incompatible matrices...");
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine($"Multiplication:\n{Matrix.Multiplication(m1, m2)}");
                        }
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
            List<Product> shoppingList = new List<Product>();
            int option = 0;
            int i;
            double total;
            while (option != 4)
            {
                total = 0;
                Console.WriteLine("\nSHOPPING LIST\n");
                for (i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                    total += shoppingList[i].Price;
                }
                Console.WriteLine($"\nTotal: {total:0.00}");
                Console.WriteLine("\nBECARIO MART\n");
                Console.WriteLine("1. Add product.");
                Console.WriteLine("2. Remove product.");
                Console.WriteLine("3. Pay.");
                Console.WriteLine("4. Exit.");
                Console.Write("Your option: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    option = 0;
                    Console.WriteLine("Only numbers, try again...");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        shoppingList.Add(Product.Create());
                        break;
                    case 2:
                        if (shoppingList.Count == 0)
                        {
                            Console.WriteLine("Shopping list is empty...");
                            continue;
                        }
                        int index;
                        try
                        {
                            index = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Only numbers, try again...");
                            continue;
                        }
                        if (index <= 0 || index > shoppingList.Count)
                        {
                            Console.WriteLine("Index out of bounds...");
                            continue;
                        }
                        shoppingList.RemoveAt(index - 1);
                        break;
                    case 3:
                        if (total <= 500)
                        {
                            Console.WriteLine("THANKS FOR YOUR PURCHASE!");
                            shoppingList.Clear();
                        }
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
                VintageCar vc = new VintageCar("Thunderbird", 2005, 1.2);
                vc.Turbo = true;
                SportsCar sc = new SportsCar("P1", 1547, 1.188);
                sc.IsHybrid = true;
                Console.WriteLine(vc);
                vc.Status();
                Console.WriteLine($"Turbo: {((vc.Turbo) ? "Yes" : "No")}");
                vc.SwitchOn();
                Console.WriteLine($"\n{sc}");
                sc.Status();
                sc.SwitchHeadlightsOn();
                sc.UseSpare();
            }
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
            IClock c1 = new SolarClock();
            IClock c2 = new AnalogClock();
            IClock c3 = new DigitalClock();
            Console.WriteLine("\nSolar clock:");
            Console.WriteLine($"Time (Only hour available): {c1.GetTime()}");
            Console.Write("Alarm tune: ");
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
                    option = Convert.ToInt32(Console.ReadLine());
                }
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
                            n1 = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            n1 = 0;
                            Console.WriteLine("Only numbers...");
                        }
                        catch (OverflowException)
                        {
                            n1 = 0;
                            Console.WriteLine("Number is too large...");
                        }
                        break;
                    case 2:
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
                        try
                        {
                            Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine($"{n1} X {n2} = {n1 * n2}");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
                        break;
                    case 6:
                        try
                        {
                            if (n2 == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            Console.WriteLine($"{n1} / {n2} = {n1 / n2}");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Result is too large...");
                        }
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
            Bird b1 = new Bird("Canary");
            Bird b2 = new FlightlessBird("Dodo", false);
            Console.WriteLine($"\n{b1}");
            b1.Fly();
            Console.WriteLine($"\n{b2}");
            try
            {
                b2.Fly();
            }
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
            List<Train> trains = new List<Train>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int type = rnd.Next(0, 3);
                if (type == 0)
                {
                    trains.Add(new Train("Basic Train", 50));
                }
                else if (type == 1)
                {
                    trains.Add(new SteamLocomotive("Steam Train", 120, "Coal",
                                                   1000.5));
                }
                else
                {
                    trains.Add(new HighSpeedTrain("Magnetic Train", 590, true));
                }
            }
            foreach (Train t in trains)
            {
                Console.WriteLine($"\n{t}");
                t.Advance();
                try
                {
                    t.Reverse();
                }
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
            string fileName;
            string data;
            do
            {
                Console.Write("Insert file name: ");
                fileName = Console.ReadLine();
            } while (fileName == string.Empty);
            do
            {
                Console.WriteLine("Insert data to append to file:");
                data = Console.ReadLine();
            } while (data == string.Empty);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = Path.Combine(path, "RMRHomework3");
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Creating directory: {path}");
                Directory.CreateDirectory(path);
            }
            Console.WriteLine($"Writing to {Path.Combine(path, fileName)}");
            File.AppendAllText(Path.Combine(path, fileName), data);
            Console.WriteLine("Done!");
        }
        // ********************************************************************

        static void Main(string[] args)
        {
            int option = 0;
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
                    option = Convert.ToInt32(Console.ReadLine());
                }
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
