using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number of students to score: ");
            int numStudents = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[numStudents];
            int i;
            for (i = 0; i < numStudents; i++)
            {
                Console.WriteLine(String.Format("\nStudent {0} data:", i + 1));
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Paternal Surname: ");
                string surname1 = Console.ReadLine();
                Console.Write("Maternal Surname: ");
                string surname2 = Console.ReadLine();
                Console.Write("Project score: ");
                int projectScore = Convert.ToInt32(Console.ReadLine());
                Console.Write("Delivered Tasks (0 - 5): ");
                int deliveredTasks = Convert.ToInt32(Console.ReadLine());
                Console.Write("Student participation (0 - inf): ");
                int studentParticipation = Convert.ToInt32(Console.ReadLine());
                students[i] = new Student(name, surname1, surname2,
                                          projectScore, deliveredTasks,
                                          studentParticipation);
            }
            Console.WriteLine("\nCalculating final scores...\n");
            for (i = 0; i < numStudents; i++)
            {
                Console.WriteLine(students[i]);
                Console.WriteLine(String.Format("Final Score: {0}\n",
                                  Calculator.GetFinalScore(students[i])));
            }
            Console.ReadKey(true);
        }
    }
}
