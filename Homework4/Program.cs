using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework4
{
    class Program
    {
        /// <summary>
        /// Console Simulation...
        /// </summary>
        /// <param name="args">Not needed</param>
        static void Main(string[] args)
        {
            // Console
            ConsoleExplorer explorer = new ConsoleExplorer();
            // Command history
            List<string> history = new List<string>();
            // User input
            string input;
            // Method result
            string result;
            // String.Split auxiliar
            string[] arguments;
            do
            {
                // Console prompt
                Console.Write($"{explorer.CurrentPath}> ");
                // Input
                input = Console.ReadLine();
                // Split input (all spacing)
                arguments = Regex.Split(input, @"\s+")
                    .Where(s => !String.IsNullOrEmpty(s)).ToArray();
                // No command, continue...
                if (arguments.Length == 0)
                {
                    continue;
                }
                // Add command to history
                history.Add(input);
                // Commands
                switch (arguments[0])
                {
                    // dir command
                    case "dir":
                        // No arguments, use current path
                        if (arguments.Length == 1)
                        {
                            result = explorer.ListContents();
                        }
                        // 1 argument, use specified path
                        else if (arguments.Length == 2)
                        {
                            result = explorer.ListContents(arguments[1]);
                        }
                        // No need for more than 1 argument, fail...
                        else
                        {
                            result = "Too many arguments...\n";
                        }
                        // Print contents
                        Console.WriteLine(result);
                        break;
                    // cd command
                    case "cd":
                        // 1 argument, try to change path
                        if (arguments.Length == 2)
                        {
                            result = explorer.ChangeDirectory(arguments[1]);
                        }
                        // No arguments, fail...
                        else if (arguments.Length == 1)
                        {
                            result = "Directory path is missing...";
                        }
                        // No need for more than 1 argument, fail...
                        else
                        {
                            result = "Too many arguments...";
                        }
                        // result is not null -> error...
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    // touch command
                    case "touch":
                        // 1 argument, try to create file
                        if (arguments.Length == 2)
                        {
                            result = explorer.CreateFile(arguments[1]);
                        }
                        // No file path/name, fail...
                        else if (arguments.Length == 1)
                        {
                            result = "File path is missing...";
                        }
                        // No need for more than 1 argument, fail...
                        else
                        {
                            result = "Too many arguments...";
                        }
                        // result is not null -> error...
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    // move command
                    case "move":
                        // 2 arguments, try to move file
                        if (arguments.Length == 3)
                        {
                            result = explorer.MoveFile(arguments[1],
                                                       arguments[2]);
                        }
                        // 1 or 2 paths missing, fail...
                        else if (arguments.Length < 3)
                        {
                            result = "File/Destination path is missing...";
                        }
                        // No need for more than 2 arguments, fail...
                        else
                        {
                            result = "Too many arguments...";
                        }
                        // result is not null -> error...
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    // history command
                    case "history":
                        // 1 or more arguments, fail...
                        if (arguments.Length != 1)
                        {
                            Console.WriteLine("No arguments...");
                            continue;
                        }
                        // Print used commands
                        foreach (string cmd in history)
                        {
                            Console.WriteLine(cmd);
                        }
                        break;
                    // cls command
                    case "cls":
                        // 1 or more rguments, fail...
                        if (arguments.Length != 1)
                        {
                            Console.WriteLine("No arguments...");
                            continue;
                        }
                        // Clear console
                        Console.Clear();
                        break;
                    // exit command
                    case "exit":
                        // Nothing
                        break;
                    default:
                        // Unknown command, fail...
                        Console.WriteLine("Unknown command...");
                        break;
                }
                // Waiting for exit command
            } while (!input.Equals("exit"));
        }
    }
}
