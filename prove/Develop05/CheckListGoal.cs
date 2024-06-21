class CheckListGoal : Goal{
    private int _runningTotal = 0;
    private int _reps = 0;
    private int _factor;
    private int _reward;
    public CheckListGoal(int factor,int reward,string name,DateTime date) : base(name,date){
        _factor = factor;
        _reward = reward;
    }
}