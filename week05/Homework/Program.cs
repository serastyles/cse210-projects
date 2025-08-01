using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment BaseAssignment = new Assignment("Samuel Bennet", "Fractions");
        Console.WriteLine(BaseAssignment.GetSummary());

        Console.WriteLine();
        MathAssignment mathAssignment = new MathAssignment("Samuel Bennet", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}