using System;

class Program{
    static void Main(string[] args){
        Console.Write("Enter First Name? ");
        string first = Console.ReadLine();
        Console.Write("Enter Last Name? ");
        string last = Console.ReadLine();
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}