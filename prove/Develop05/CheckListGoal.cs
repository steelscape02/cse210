class CheckListGoal : Goal{
    private static List<CheckListGoal> _checkListGoals = [];
    private int _runningTotal = 0;
    private int _reps;
    private int _factor;
    private int _reward;
    private string _name;
    private bool _completed = false;

    private static string _self = "CheckList";

    public CheckListGoal(int factor,int reps,int reward,string name,DateTime date) : base(name,_self,date,false){
        _factor = factor;
        _reward = reward;
        _reps = reps;
        _name = name;
        _checkListGoals.Add(this);
    }

    public int CompleteOnce(){
        _runningTotal += _factor;
        _reps -=1;
        UpdatePoints(_name,_runningTotal);
        return _reps;
    }
    public int GetReps(){return _reps;}

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

        CheckListGoal checkList = new(factor,reps,reward,name,DateTime.Now);
        return checkList;
    }

    public static CheckListGoal FindCheckListGoal(string name = "", bool mute = false){
        foreach(CheckListGoal checkList in _checkListGoals){
            if(checkList.GetName() == name){return checkList;}
        }
        if(mute == false){Console.WriteLine($"No goal found under name {name}");}
        return null;
    }

    public override void CloseGoal()
    {
        UpdateTotal(_runningTotal);
        CompleteGoal(_name,_runningTotal);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }
}