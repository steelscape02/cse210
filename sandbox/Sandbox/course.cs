using System.ComponentModel.DataAnnotations;

class Course
{
    public string _courseCode; //underscore as convention
    public string _className;
    public int _numberOfCredits;
    public string _color;

    //method
    public void Display(){
        Console.WriteLine($"{_courseCode}\n{_className}\n{_numberOfCredits}");
    }
}