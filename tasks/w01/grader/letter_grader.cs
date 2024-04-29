using System;

class Program{
    static void Main(string[] args){
        Console.Write("Please enter percent grade: ");
        int percent_grade = Convert.ToInt32(Console.ReadLine());
        char letter_grade = 'A';
        char lean = '+';
        if(percent_grade >= 90){
            letter_grade = 'A';
        }
        else if(percent_grade >= 80){
            letter_grade = 'B';
        }
        else if(percent_grade >= 70){
            letter_grade = 'C';
        }
        else if(percent_grade >= 60){
            letter_grade = 'D';
        }
        else{
            letter_grade = 'F';
        }
        int last_digit = percent_grade % 10;
        if(percent_grade <=90 ^ percent_grade <= 60){
            if(last_digit >= 7){
                lean = '+';
            }
            else if(last_digit <3){
                lean = '-';
            }
            else{
                lean = '\0';
            }
        }
        else{
            lean = '\0';
        }
        Console.WriteLine($"Your Grade is {letter_grade}{lean}");
    }
}