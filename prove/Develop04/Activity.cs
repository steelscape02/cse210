using System.ComponentModel;
using System.Data.Common;

class Activity{
    private int _length;
    private string _datetime;
    private string _activityName;
    private string _entryName;

    public Activity(string datetime = "",string entryName = "",string activityName = "", int length = 0){
        _datetime = datetime;
        _entryName = entryName;
        _activityName = activityName;
        _length = length;
    }

    public void StartActivity(){
        Console.WriteLine($"Welcome to a {_activityName} activity.\nThis activity will last {_length} seconds.");
        Thread.Sleep(1000);
    }

    public void EndActivity(){
        Console.WriteLine($"\nThank you for completing: {_entryName}");
    }

    public void LoadingBar(int length = 0, int style = 0){ //(length is time in s) - multiple styles, one with beep function
        int left,top;
        (left,top) = Console.GetCursorPosition();
        int index = 0;
        int pause = 1000;
        switch(style){
            case 0: //no nonsense one character loading bar
                while(length > 0){
                    Console.SetCursorPosition(left,top);
                    switch(index){
                        case 0: Console.Write("-");break;
                        case 1: Console.Write("\\");break;
                        case 2: Console.Write("|");break;
                        case 3: Console.Write("/");break;
                    }
                    if(index>=3){index = 0;}else{index +=1;}
                    length -=1;
                    Thread.Sleep(pause);
                }
                break;
            case 1: //4 bit loading bar with 'bouncing' asterisk
                while(length > 0){
                    Console.SetCursorPosition(left,top);
                    switch(index){
                        case 0: Console.Write("*===");break;
                        case 1: Console.Write("=*==");break;
                        case 2: Console.Write("==*=");break;
                        case 3: Console.Write("===*");break;
                        case 4: Console.Write("==*=");break;
                        case 5: Console.Write("=*==");Console.Beep();break;
                    }
                    if(index>=5){index =0;}else{index+=1;}
                    length -=1;
                    Thread.Sleep(pause);
                }
                break;
        }
    }
}