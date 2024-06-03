using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment class1 = new("Samuel Bennett","Multiplication");
        Console.WriteLine(class1.GetSummary());

        Console.Write("\n");

        MathAssignment mathclass1 = new("Roberto Rodriguez","Fractions","7.3","8-19");
        Console.WriteLine(mathclass1.GetHomeworkList());

        Console.Write("\n");

        WritingAssignment writingclass1 = new("Mary Waters","European History","The Causes of World War II by Mary Waters");
        Console.WriteLine(writingclass1.GetWritingInformation());
    }
}