class SimpleGoal : Goal{
    private static List<SimpleGoal> _simpleGoals = [];
    private int _reward;
    private string _name;
    private bool _completed = false;
    private static string _self = "Simple";


    public SimpleGoal(string name,bool completed,DateTime date,int reward) : base(name,completed,date,_self){
        _reward = reward;
        _name = name;
        _completed = completed;
        _simpleGoals.Add(this);
        Thread.Sleep(500);
    }

    public static SimpleGoal CreateSimpleGoal(string name = "",int reward = 0){
        Console.Write("Please Enter the name of the goal: ");
        name = Console.ReadLine();
        Console.Write("Enter the reward for completing this goal (as a number): ");
        reward = Convert.ToInt32(Console.ReadLine());
        SimpleGoal simple = new(name,false,DateTime.Now,reward);
        return simple;
    }

    public static SimpleGoal FindSimpleGoal(string name = "",bool mute = false){
        foreach(SimpleGoal simple in _simpleGoals){
            if(simple.GetName() == name){return simple;}
        }
        if(mute == false){Console.WriteLine($"No goal found under name {name}");}
        return null;
    }

    public static List<SimpleGoal> ExportGoals(){return _simpleGoals;}
    public void GetTotalSimple(){
        int grandTotal = 0;
        foreach(SimpleGoal simple in _simpleGoals){
            if(simple._completed == true){grandTotal += simple._reward;}
        }
        UpdateTotal(grandTotal);
    }
    public int GetReward(){return _reward;}
    public bool GetComplete(){return _completed;}

    public override void CloseGoal()
    {
        UpdateTotal(_reward);
        CompleteGoal(_name,_reward);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }
}