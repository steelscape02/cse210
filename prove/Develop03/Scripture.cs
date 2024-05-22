
using System.Text;


class Scripture(){
    private int _length;
    static private List<Word> _words = [];
    private string _name;

    public void SetPhrase(string id,string phrase){ //id is scripture name, phrase is scripture
        _name = id;
        string[] word_list = phrase.Split(" ");
        _length = word_list.Length;
        foreach(string item in word_list){
            Word word = new();
            word.SetWord(item);
            _words.Add(word);
        }
    }

    public int GetLength(){return _length;}

    public void Advance(){
        var rand = new Random();
        int index = rand.Next(_words.Count());
        if(_words[index]._empty == false){
            _words[index].MakeEmpty();
        }else{
            int total_len = _words.Count - index;
            while(_words[index]._empty == true && total_len > 0){
                index = rand.Next(_words.Count());
                total_len -= index;
            }
            if(total_len <= 0){
                Console.Clear();
                Console.WriteLine("Good Job!");
            }else{
                _words[index].MakeEmpty();
            }
        }   
    }

    public void Display(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        var builder = new StringBuilder();
        foreach(Word word in _words){
            builder.Append(word.GetWord());
            builder.Append(' ');
        }
        string scripture = builder.ToString();
        Console.Write(_name);
        Console.Write("\n");
        Console.Write(scripture);
    }
}