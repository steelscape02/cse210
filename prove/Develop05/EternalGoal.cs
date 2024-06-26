class EternalGoal : Goal{
    private static List<EternalGoal> _eternalGoals = [];
    private int _factor;
    private int _runningTotal = 0;
    private string _name;
    private bool _completed = false;
    private static string _self = "Eternal";

    public EternalGoal(string name,bool completed,DateTime date,int factor) : base(name,completed,date,_self){
        _factor = factor;
        _name = name;
        _completed = completed;
        _eternalGoals.Add(this);

    }
    
    public void SetRunning(int runningTotal){_runningTotal = runningTotal;}
    public void CompleteOnce(){
        _runningTotal += _factor;
        UpdatePoints(_name,_runningTotal);
    }

    public static EternalGoal CreateEternalGoal(){
        Console.Write("Please Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the reward that should be given each time this goal is completed (as a number): ");
        int factor = Convert.ToInt32(Console.ReadLine());
        EternalGoal eternal = new(name,false,DateTime.Now,factor); //passing in false as default param for completed
        return eternal;
    }

    public static EternalGoal FindEternalGoal(string name = "", bool mute = false){
        foreach(EternalGoal eternal in _eternalGoals){
            if(eternal.GetName() == name){return eternal;}
        }
        if(mute == false){Console.WriteLine($"No goal found under name {name}");}
        return null;
    }
    public static bool RemoveEternalGoal(string name = "",bool addPoints = false){
        foreach(EternalGoal eternal in _eternalGoals){
            if(eternal.GetName() == name){
                if(addPoints == true){eternal.UpdateTotal(eternal._runningTotal);}
                _eternalGoals.Remove(eternal);
                return true;
            }
        }
        return false;
    }
    public static List<EternalGoal> ExportGoals(){return _eternalGoals;}

    protected void GetTotalPoints(){
        int grandTotal = 0;
        foreach(EternalGoal eternal in _eternalGoals){
            grandTotal += eternal._runningTotal;
        }
        UpdateTotal(grandTotal);
    }
    public int GetFactor(){return _factor;}
    public int GetRunningTotal(){return _runningTotal;}
    public bool GetComplete(){return _completed;}

    public override void CloseGoal()
    {
        UpdateTotal(_runningTotal);
        CompleteGoal(_name,_runningTotal);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }

}