using System;

class Program
{
    static void Main(string[] args)
    {
        Course course1 = new Course(); //call type, name var, set new and class initializer
        course1._className = "Programming with Classes";
        course1._color = "Green";
        course1._courseCode = "CSE 210";
        course1._numberOfCredits = 2;
        course1.Display(); //accesses associated member variables using format writeline
    }
}


