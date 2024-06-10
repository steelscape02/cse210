class Breathing : Activity{
    private int _length;
    private int _pauseLength = 5; //seconds
    public Breathing(int length, string datetime, string activity) : base(datetime,activity,length){_length = length;}

    public void StartBreathing(){
        int actLength = _length;
        actLength /=(_pauseLength*2); //split to turn length given into cycles completed
        while(actLength > 0){
            Console.WriteLine("\nBreath in\n");
            LoadingBar(1);
            Console.WriteLine("\nBreath out\n");
            LoadingBar(1);  
            actLength -=1;
        }
    }
}