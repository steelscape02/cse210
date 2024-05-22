

using System.Text;


class Scripture(){
    
    static private List<Word> _words = [];
    private string _name;

    public void SetPhrase(string id,string phrase){ //id is scripture name, phrase is scripture
        _name = id;
        string[] word_list = phrase.Split(" ");

        foreach(string item in word_list){
            Word word = new();
            word.SetWord(item);
            _words.Add(word);
        }
    }
    public void Advance(){
        var rand = new Random();
        int index = rand.Next(_words.Count());
        if(_words[index]._empty == false){
            _words[index].MakeEmpty();
        }else{
            while(_words[index]._empty == true){
                index = rand.Next(_words.Count());
                
            }
        }
        
        
    }
    public void Display(){
        Console.SetCursorPosition(0,0);
        Console.WriteLine(_name);
        var builder = new StringBuilder();
        foreach(Word word in _words){
            builder.Append(word.GetWord());
            builder.Append(' ');
        }
        string scripture = builder.ToString();
        Console.WriteLine(_name);
        Console.Write(scripture);
    }
}