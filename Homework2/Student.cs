using System;

namespace Homework2
{
    class Student
    {
        public string Name { get; set; }

        public string Surname1 { get; set; }

        public string Surname2 { get; set; }

        public int ProjectScore { get; set; }

        public int DeliveredTasks { get; set; }

        public int StudentParticipation { get; set; }

        private Student() { }

        public Student(string name, string surname1, string surname2)
        {
            this.Name = name;
            this.Surname1 = surname1;
            this.Surname2 = surname2;
            this.ProjectScore = 0;
            this.DeliveredTasks = 0;
            this.StudentParticipation = 0;
        }
        public Student(string name, string surname1, string surname2, 
                       int projectScore, int deliveredTasks, 
                       int studentParticipation)
        {
            this.Name = name;
            this.Surname1 = surname1;
            this.Surname2 = surname2;
            this.ProjectScore = projectScore;
            this.DeliveredTasks = deliveredTasks;
            this.StudentParticipation = studentParticipation;
        }
        public override string ToString()
        {
            return String.Format("Student: {0} {1} {2}", this.Name,
                                 this.Surname1, this.Surname2);
        }
    }
}