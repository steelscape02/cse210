using System;
using System.ComponentModel;
using System.Security.Cryptography;

class Program
{
    static int ShowMenu(bool first){
        if(first == true){Console.WriteLine("Welcome to Goal Setter!\n");}
        else{Console.WriteLine("Options:\n");}
        
        Console.WriteLine("1. Work on an existing goal");
        Console.WriteLine("2. Create a new goal");
        Console.WriteLine("3. Display all goals");

        Console.WriteLine("4. End Program");

        Console.Write("\nPlease select option: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if((choice % 1) != 0 || choice > 4 || choice < 1){Console.WriteLine("Invalid Option");ShowMenu(first);}
        return choice;
    }

    static Goal ChooseExisting(){
        int length = Goal.DisplayExisting();
        if(length ==0){return null;}
        Console.Write("Please select a goal number: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if(choice > length){Console.WriteLine("Invalid goal selection");ChooseExisting();}
        Goal existing = Goal.FindGoal(choice);
        return existing;
    }

    static void ExistingMenu(string name){
        SimpleGoal simple = SimpleGoal.FindSimpleGoal(name,true);
        EternalGoal eternal = EternalGoal.FindEternalGoal(name,true);
        CheckListGoal checkList = CheckListGoal.FindCheckListGoal(name,true);
        string type = "";
        if(simple != null){type = "Simple";}
        else if(eternal != null){type = "Eternal";}
        else if(checkList != null){type = "CheckList";}
        Console.WriteLine($"type: {type}");
        Thread.Sleep(500);
        Console.WriteLine("Choose number of desired action:\n");
        int choice;
        switch(type){
            case "Simple":
                Console.WriteLine("1. Complete Goal");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1){
                    Console.WriteLine("Goal Closed");
                    simple.CloseGoal();
                }
                break;
            case "Eternal":
                Console.WriteLine("1. Add an occurance");
                Console.WriteLine("2. Complete Goal");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1){
                    eternal.CompleteOnce();
                    Console.WriteLine("Occurance added");
                }
                if(choice == 2){
                    eternal.CloseGoal();
                    Console.WriteLine("Goal Closed");
                }
                break;
            case "CheckList":
                Console.WriteLine("1. Add an occurance");
                Console.WriteLine("2. Check the number of completions remaining");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1){
                    int reps = checkList.CompleteOnce();
                    Console.WriteLine($"Occurance added. You have {reps} completions remaining");
                }
                if(choice == 2){
                    int reps = checkList.GetReps();
                    Console.WriteLine($"You have {reps} completions remaining");
                }
                break;
            default:
                Console.WriteLine("Goal not found..");
                Thread.Sleep(500);
                break;
        }
    }

    static void NewGoal(){
        Console.WriteLine("Goal Options:\n");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        Console.Write("Please enter goal type number: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch(choice){
            case 1:
                SimpleGoal simple = SimpleGoal.CreateSimpleGoal();
                break;
            case 2:
                EternalGoal eternal = EternalGoal.CreateEternalGoal();
                break;
            case 3:
                CheckListGoal checkList = CheckListGoal.CreateCheckListGoal();
                break;
            default:
                Console.WriteLine("Type number entered is invalid..");
                Thread.Sleep(500);
                break;
        }
    }

    static void SaveGoals(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Saving to file..");
        Thread.Sleep(500);
        Goal.Write();
    }

    static void LoadGoals(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Loading from file..");
        Thread.Sleep(500);
        Goal.Read();
    }

    static void Main(string[] args)
    {
        LoadGoals();
        bool quit = false;
        bool first = true;
        do{
            Console.Clear();
            Console.SetCursorPosition(0,0);
            int choice = ShowMenu(first);
            switch(choice){
                case 1:
                    try{
                        Goal existing = ChooseExisting();
                        ExistingMenu(existing.GetName());
                    }catch(System.NullReferenceException){
                        Console.Clear();
                        Console.SetCursorPosition(0,0);
                        Console.WriteLine("No existing goals.");
                        Thread.Sleep(1000);
                    }      
                    break;
                case 2:
                    NewGoal();
                    break;
                case 3:
                    Goal.Display();
                    break;
                case 4:
                    SaveGoals();
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Option not found");
                    Thread.Sleep(500);
                    break;
            }
            first = false;
        }while(quit == false);
    }
}