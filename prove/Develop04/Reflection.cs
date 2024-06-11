using System.ComponentModel.DataAnnotations;

class Reflection : Activity{
    private static readonly string _self = "reflection";
    private int _length;
    private int _reflectTime = 5;

    public Reflection(int length,string datetime,string entryName) : base(datetime,entryName,"Reflection",length){_length=length;}

    public void StartReflection(){
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        int actLength = _length;
        string prompt;
        string question;
        
        while(actLength > 0){
            Prompt reflect = new();
            reflect.SetLists();
            prompt = reflect.GetPrompt(_self);
            Console.WriteLine($"\n{prompt}");
            Thread.Sleep(1000);
            actLength -= 1;
            question = reflect.GetQuestion(_self);
            Console.WriteLine($"\n{question}");
            LoadingBar(_reflectTime,0);
            actLength -= _reflectTime;
        }
    }
}