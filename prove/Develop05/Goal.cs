using System.Configuration.Assemblies;
using System.Runtime.CompilerServices;

class Goal{
    private List<Goal> _goals = [];

    private int _totalPoints;
    private int _points;
    private string _name;
    private DateTime _date;
    private string _cwd = Directory.GetCurrentDirectory();
    private string _filename = "text.txt";

    public Goal(string name,DateTime date){
        _name = name;
        _date = date;
        _goals.Add(this);
    }

    public virtual int GetPoints(){return _totalPoints;}

    public string GetName(){return _name;}


    public void Display(){
        foreach(Goal goal in _goals){
            Console.WriteLine($"Goal Type: {goal._name}\nPoints awarded: {goal._points}\nCompleted on: {goal._date}\n");
        }
    }
    
    public void CloseGoal(){
        //close goal and add to totalPoints. ADD _points to object (delete from list (so that it'll delete from file on next write op), increment totalPoints by value)
    }

    public void Write(){
        using (StreamWriter sw = new StreamWriter(_cwd + _filename)){
            string line;
            foreach(Goal goal in _goals){
                line = $"{goal._name};{goal._points};{goal._date}";
                sw.WriteLine(line);
            }
        }
    }
    public void Read(){

    }
}