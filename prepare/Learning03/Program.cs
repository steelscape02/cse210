using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new();
        fraction.OneToOne();
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());

        fraction.OverOne(5);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        
        fraction.SetFraction(3,4);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}