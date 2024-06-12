using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
        int length;
        DateTime datetime = DateTime.Now;
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity\n");
        Console.Write("Enter desired activity number: ");
        choice = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter desired activity length (in seconds): ");
        length = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n");
        switch(choice){
            case 1:
                Breathing breathing = new(length,datetime.ToString(),$"Breathing on {datetime}");
                breathing.StartActivity();
                breathing.StartBreathing();
                breathing.EndActivity();
                break;
            case 2:
                Reflection reflection = new(length,datetime.ToString(),$"Reflection on {datetime}");
                reflection.StartActivity();
                reflection.StartReflection();
                reflection.EndActivity();
                break;
            case 3:
                Listing listing = new(length,datetime.ToString(),$"Listing on {datetime}");
                listing.StartActivity();
                listing.StartListing();
                listing.EndActivity();
                break;
        }
    }
}