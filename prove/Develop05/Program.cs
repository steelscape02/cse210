using System;

class Program
{
    static void Main(string[] args)
    {
        Goal goal = new("BIG",DateTime.Now);
        goal.Display();
    }
}