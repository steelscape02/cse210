using System.Collections.Generic;
//Exceeds Requirements: Added mood to Entry. Every time a new entry is created, the mood of the user is recorded.

class Program
{
    static void Run(Journal journal){
        //start
        int choice = 0;
        do{
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Exit Program\n");

            Console.Write("Choose Option: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice){
                case 1:
                    journal.NewEntry();
                    break;
                case 2:
                    Journal.Display();
                    break;
                case 3:
                    Journal.Save();
                    break;
                case 4:
                    Journal.Load();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return;
            }
        }while(choice != 0);
    }
    static void Main(string[] args)
    {
        Journal journal = new();
        Run(journal);
    }
}