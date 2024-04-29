using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name,squared);
    }
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName(){
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber(){
        Console.Write("Enter Favorite Number: ");
        int favorite_number = Convert.ToInt32(Console.ReadLine());
        return favorite_number;
    }
    static int SquareNumber(int number){
        return number * number;
    }
    static void DisplayResult(string name,int squared){
        Console.WriteLine($"{name}, the square of your favorite number is {squared}");
    }
}