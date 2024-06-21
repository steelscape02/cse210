class EternalGoal : Goal{
    private int _factor;
    private int _streak = 0;
    private int _reps = 0;
    private int _runningTotal = 0;

    public EternalGoal(int factor,string name,DateTime date) : base(name,"Eternal",date){_factor = factor;}

    public override int GetPoints()
    {
        return _runningTotal;
    }

}