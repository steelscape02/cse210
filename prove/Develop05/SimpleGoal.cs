class SimpleGoal : Goal{
    private int _reward;

    public SimpleGoal(int reward,string name,DateTime date) : base(name,"Simple",date){_reward = reward;}

    public override int GetPoints()
    {
        return _reward;
    }
}