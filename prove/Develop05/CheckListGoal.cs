class CheckListGoal : Goal{
    private static List<CheckListGoal> _checkListGoals = [];
    private int _runningTotal = 0;
    private int _reps;
    private int _totalReps;
    private int _factor;
    private int _reward;
    private string _name;
    private bool _completed = false;

    private static string _self = "CheckList";

    public CheckListGoal(string name,bool completed,DateTime date,int factor,int reps,int reward) : base(name,completed,date,_self){
        _factor = factor;
        _reward = reward;
        _reps = reps;
        _totalReps = reps;
        _name = name;
        _completed = completed;
        _checkListGoals.Add(this);
    }
    
    public int CompleteOnce(){
        _runningTotal += _factor;
        _reps -=1;
        UpdatePoints(_name,_runningTotal);
        return _reps;
    }

    public static CheckListGoal CreateCheckListGoal(){
        Console.Write("Please Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the reward that should be given each time this goal is completed (as a number): ");
        int factor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the number of times that this goal needs to be accomplished: ");
        int reps = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a final reward (default is your reward number multiplied by 50): ");
        string rewRaw = Console.ReadLine();
        int reward;
        if(rewRaw != "" && rewRaw != null){reward = Convert.ToInt32(rewRaw);}
        else{reward = factor * 50;}

        CheckListGoal checkList = new(name,false,DateTime.Now,factor,reps,reward); //passing in false as default param for completed
        return checkList;
    }

    public static CheckListGoal FindCheckListGoal(string name = "", bool mute = false){
        foreach(CheckListGoal checkList in _checkListGoals){
            if(checkList.GetName() == name){return checkList;}
        }
        if(mute == false){Console.WriteLine($"No goal found under name {name}");}
        return null;
    }
    public static bool RemoveCheckListGoal(string name = "",bool addPoints = false){
        foreach(CheckListGoal checkList in _checkListGoals){
            if(checkList.GetName() == name){
                if(addPoints == true){checkList.UpdateTotal(checkList._runningTotal);}
                _checkListGoals.Remove(checkList);
                return true;
            }
        }
        return false;
    }
    public static List<CheckListGoal> ExportGoals(){return _checkListGoals;}
    protected void GetTotalPoints(){
        int grandTotal = 0;
        foreach(CheckListGoal checkListGoal in _checkListGoals){
            grandTotal += checkListGoal._runningTotal;
        }
        UpdateTotal(grandTotal);
    }

    public void SetRunning(int runningTotal){_runningTotal = runningTotal;}
    public void SetRepTotal(int repTotal){_totalReps = repTotal;}

    public int GetFactor(){return _factor;}
    public int GetReward(){return _reward;}
    public int GetReps(){return _reps;}
    public int GetTotalReps(){return _totalReps;}
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