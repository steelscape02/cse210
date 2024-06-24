class EternalGoal : Goal{
    private static List<EternalGoal> _eternalGoals = [];
    private int _factor;
    private int _runningTotal = 0;
    private string _name;
    private bool _completed = false;
    private static string _self = "Eternal";

    public EternalGoal(int factor,string name,DateTime date) : base(name,_self,date,false){
        _factor = factor;
        _name = name;
        _eternalGoals.Add(this);
    }

    public void CompleteOnce(){
        _runningTotal += _factor;
        UpdatePoints(_name,_runningTotal);
    }

    public static EternalGoal CreateEternalGoal(){
        Console.Write("Please Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the reward that should be given each time this goal is completed (as a number): ");
        int factor = Convert.ToInt32(Console.ReadLine());
        EternalGoal eternal = new(factor,name,DateTime.Now);
        return eternal;
    }

    public static EternalGoal FindEternalGoal(string name = "", bool mute = false){
        foreach(EternalGoal eternal in _eternalGoals){
            if(eternal.GetName() == name){return eternal;}
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