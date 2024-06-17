using System.Reflection.Metadata.Ecma335;

class Square : Shape{
    private double _side;
    public Square(double side, string color) : base("Square",color){_side = side;}

    public override double GetArea()
    {
        return Math.Pow(_side,2);
    }
}