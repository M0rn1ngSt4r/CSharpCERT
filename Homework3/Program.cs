﻿using System;
using System.Collections.Generic;
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
                Console.WriteLine($"Sum of first {n} natural numbers is: {NSum(n)}");
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
