class SimpleGoal : Goal{
    private int _reward;

    public SimpleGoal(int reward,string name,DateTime date) : base(name,date){_reward = reward;}

    public override int GetPoints()
    {
        return _reward;
    }
}