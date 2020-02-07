namespace Homework2
{
    static class Calculator
    {
        public static double GetFinalScore(Student student)
        {
            double score = student.ProjectScore * 0.6 +
                           student.DeliveredTasks * 10 / 5 * 0.4 +
                           ((student.StudentParticipation > 5) ? 0.8 : 0.0);
            return (score < 5) ? 5 : (score > 10) ? 10 : score;
        }
    }
}