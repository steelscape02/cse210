class Shape{
    private string _color;
    private string _type;

    public Shape(string type, string color){_color = color;_type = type;}

    public string GetColor(){return _color;}
    public string GetShape(){return _type;}
    public void SetColor(string color){_color = color;}
    public virtual double GetArea(){
        return 0f;
    }
}