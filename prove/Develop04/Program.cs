using System;

class Program
{
    static void Main(string[] args)
    {
        bool endProgram = false;
        int sessionCount = 0;
        while(endProgram == false){
            int choice;
            int length;
            DateTime datetime = DateTime.Now;
            if(sessionCount == 0){Console.WriteLine("Welcome to your meditation app. Please select an activity: \n");}
            else{Console.WriteLine("Please select an activity: \n");}
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. End Program\n");
            Console.Write("Enter the number of the desire option: ");

            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 4){break;}
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
            sessionCount += 1;
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Thank you for taking time to meditate. Have a great day!");
    }
}