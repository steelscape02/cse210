using System.Diagnostics;
using System.Runtime.InteropServices;

class Listing : Activity{
    private static readonly string _self = "listing";
    private int _length;
    private List<string> _responses = [""];

    public Listing(int length, string datetime, string entryName) : base(datetime,entryName,"Listing",length){_length = length;}

    public void StartListing(){
        // Console.Clear();
        // Console.SetCursorPosition(0,0);
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        double actLength = _length; //alterable variable for decrement loop
        string prompt;

        Prompt lister = new();
        lister.SetLists();
        prompt = lister.GetQuestion(_self);
        Console.WriteLine($"\n{prompt}");
        LoadingBar(5,1);
        Console.Write("\n\n");
        int left,top;
        (left,top) = Console.GetCursorPosition();
        string response = "";
        while(actLength > 0){
            if(Console.KeyAvailable){
                Console.SetCursorPosition(left,top-1);
                
                Console.Write(":");
                response = Console.ReadLine();
                _responses.Add(response);
                Console.Write("\n");
            }
            
            Console.SetCursorPosition(left,top-1);
            Console.Write(actLength);
            if(actLength > 0){
                Thread.Sleep(1000);
                actLength -= 1;
            }else if(actLength <= 0){
                break;
            }
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine($"\nYou recorded {_responses.Count()-1} thoughts:"); //-1 to remove count for initializer
        foreach(string res in _responses){
            Console.WriteLine($"{res}");
        }
        Thread.Sleep(3000);
    }
}