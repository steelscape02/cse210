using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new(10,"blue");
        Console.WriteLine($"Square:\nColor: {square.GetColor()}\nArea: {square.GetArea()}\n");
        Rectangle rectangle = new(10,8,"red");
        Console.WriteLine($"Rectangle:\nColor: {rectangle.GetColor()}\nArea: {rectangle.GetArea()}\n");
        Circle circle = new(5,"purple");
        Console.WriteLine($"Circle:\nColor: {circle.GetColor()}\nArea: {circle.GetArea()}\n");

        List<Shape> shapes = [];
        shapes.Add(new Square(1.0,"Yellow"));
        shapes.Add(new Rectangle(4.0,3.7,"Green"));
        shapes.Add(new Circle(5.2,"Lavender"));
        
        foreach(Shape shape in shapes){
            Console.WriteLine($"{shape.GetShape()}:\nColor: {shape.GetColor()}\nArea: {Math.Round(shape.GetArea(),2)}\n");
        }

    }
}