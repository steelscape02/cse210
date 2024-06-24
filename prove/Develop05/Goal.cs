using System.Configuration.Assemblies;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

class Goal{
    private static List<Goal> _goals = [];

    private int _totalPoints;
    private int _points;
    private bool _completed;
    private string _name;
    private string _type;
    private DateTime _date;
    

    public Goal(string name, string type, DateTime date,bool completed){
        _name = name;
        _date = date;
        _type = type;
        _completed = completed;
        _goals.Add(this);
    }

    public virtual int GetPoints(){return _totalPoints;}

    public new string GetType(){return _type;}
    public string GetName(){return _name;}

    public static void Display(){ //add as virtual class that gets $"" strings from the appropriate classes with pertinent information (like repititions completed)
        foreach(Goal goal in _goals){
            string completionDialog;
            if(goal._completed == true){completionDialog = "X";}
            else{completionDialog = " ";}
            Console.WriteLine($"Goal Type: {goal._type}\nPoints awarded: {goal._points}\nStarted on: {goal._date}\nCompleted: [{completionDialog}]\n");
        }
        Console.Write("Press any key to go back...");
        Console.ReadKey();
    }
    public static int DisplayExisting(){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._completed == false){Console.WriteLine($"{i+1}.\nName: {_goals[i]._name}\nType: {_goals[i]._type}\n");}
        }
        return _goals.Count();
    }
    public static Goal FindGoal(int index){
        try{
            Goal goal = _goals[index-1];
            return goal;
        }catch(ArgumentOutOfRangeException){
            Console.WriteLine($"Index not found\n");
            return null;
        }
        
    }
    
    public virtual void CloseGoal(){UpdateTotal(_totalPoints);_goals.Remove(this);}

    protected void CompleteGoal(string name, int points){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._completed = true;
                _goals[index]._points = points;
                break;
            }
        }
    }
    protected void UpdatePoints(string name,int points){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._points = points;
                break;
            }
        }
    }

    protected void UpdateTotal(int points){_totalPoints += points;}
    protected void RemoveGoal(){_goals.Remove(this);}

    public static void Write(){
        string _filename = "goals.txt";
        using StreamWriter sw = new(_filename,false); //false allows overwrite

        foreach(Goal goal in _goals){
            int completeStatus;
            if(goal._completed == true){completeStatus = 1;}
            else{completeStatus = 0;}
            sw.WriteLine($"{goal._name};{goal._type};{goal._points};{goal._date};{completeStatus}");
        }
        
    }
    public static void Read(){
        string _filename = "goals.txt";
        if(File.Exists(_filename)){
            using StreamReader sr = new StreamReader("TestFile.txt");
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineElem = line.Split(";");
                bool complete;
                if (Convert.ToInt32(lineElem[4]) == 1) { complete = true; }
                else { complete = false; }
                Goal goal = new(lineElem[0], lineElem[1], DateTime.Parse(lineElem[3]), complete);
                goal._points = Convert.ToInt32(lineElem[2]);
                _goals.Add(goal);
            }
        }
        else{Console.WriteLine("File Not Found");Thread.Sleep(2000);}
    }
}