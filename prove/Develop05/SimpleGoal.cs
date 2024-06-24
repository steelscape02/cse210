class SimpleGoal : Goal{
    private static List<SimpleGoal> _simpleGoals = [];
    private int _reward;
    private string _name;
    private bool _completed = false;
    private static string _self = "Simple";


    public SimpleGoal(int reward,string name,DateTime date) : base(name,_self,date,false){
        _reward = reward;
        _name = name;
        _simpleGoals.Add(this);
    }

    public static SimpleGoal CreateSimpleGoal(){
        Console.Write("Please Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the reward for completing this goal (as a number): ");
        int reward = Convert.ToInt32(Console.ReadLine());
        SimpleGoal simple = new(reward,name,DateTime.Now);
        return simple;
    }

    public static SimpleGoal FindSimpleGoal(string name = "",bool mute = false){
        foreach(SimpleGoal simple in _simpleGoals){
            if(simple.GetName() == name){return simple;}
        }
        if(mute == false){Console.WriteLine($"No goal found under name {name}");}
        return null;
    }

    //public 

    public override void CloseGoal()
    {
        UpdateTotal(_reward);
        CompleteGoal(_name,_reward);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }
}