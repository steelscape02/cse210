using System.Security.Cryptography;

class Breathing : Activity{
    private int _length;
    private int _breathIn = 4;
    private int _breathHold = 7;
    private int _breathOut = 8;
    public Breathing(int length, string datetime, string entryName) : base(datetime,entryName,"Breathing",length){_length = length;}

    public void StartBreathing(){
        int actLength = _length/(_breathIn + _breathHold + _breathOut); //split to turn length, runs for length

        while(actLength > 0){
            Console.Write("\nBreath in ");
            LoadingBar(_breathIn,1);
            Console.Write("\nHold your breath ");
            LoadingBar(_breathHold,1);
            Console.Write("\nBreath out ");
            LoadingBar(_breathOut,1);
            actLength -=1;
        }
    }
}