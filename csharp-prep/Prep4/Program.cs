using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int user_input;
        List<int> numbers = new List<int>();
        int sum = 0;
        int largest = 0;
        int low_positive = 0;
        do{
            Console.Write("Enter Number: ");
            user_input = Convert.ToInt32(Console.ReadLine());

            if(user_input != 0){
                numbers.Add(user_input);
            }
        }while(user_input != 0);
        foreach(int number in numbers){
            sum += number;
            if(number > largest){
                largest = number;
            }
            if((number > 0 && number < low_positive) || low_positive == 0){
                low_positive = number;
            }
        }
        float average = sum / numbers.Count;
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {low_positive}");
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach(int number in numbers){
            Console.WriteLine(number);
        }
    }
}