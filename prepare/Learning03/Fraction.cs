class Fraction{
    private int _top;
    private int _bottom;

    public void OneToOne(){
        _top = 1;
        _bottom = 1;
    }
    public void OverOne(int top){
        _top = top;
        _bottom = 1;
    }

    public void SetFraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    
    public void SetTop(int top){_top = top;}
    public int GetTop() {return _top;}
    public void SetBottom(int bottom) {_bottom = bottom;}
    public int GetBottom() {return _bottom;}

    public string GetFractionString(){return $"{_top}/{_bottom}";}
    public double GetDecimalValue(){
        double dec = (double)_top/(double)_bottom;
        return dec;
    }
}