using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
        int length;
        string datetime = "";
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity\n");
        Console.Write("Enter desired activity number: ");
        choice = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter desired activity length (in seconds): ");
        length = Convert.ToInt32(Console.ReadLine());
        switch(choice){
            case 1:
                Breathing breathing = new(length,datetime,$"Breathing on {datetime}");
                breathing.StartActivity();
                breathing.StartBreathing();
                break;
        }
    }
}