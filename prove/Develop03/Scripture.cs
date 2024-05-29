
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

    public bool Advance(){

        
        var rand = new Random();
        int reps = rand.Next(3); //statically set
        int index = 0;
        int prev_index = 0;
        bool empty = false;
        bool all_empty = false;
        
        do{
            rand = new Random(); //regenerate random
            index = rand.Next(_words.Count());
            if(index == prev_index){
                while(index == prev_index){
                    index = rand.Next(_words.Count());
                }
            }
            empty = _words[index].GetEmpty();
            if(empty == false){
                _words[index].MakeEmpty();
            }else{
                all_empty = true;
                foreach(Word word in _words){
                    if(word.GetEmpty() == false){
                        word.MakeEmpty();
                        all_empty = false;
                        break;
                    }
                }
                if(all_empty == true){
                    return true;
                }
            }
            reps -= 1;
            prev_index = index;
        }while(reps > 0);
        return false;
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
    public void Finish(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Goodbye");
        Thread.Sleep(5000);
        return;
    }
}