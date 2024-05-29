
using System.Text;

class Word{
    private string _word;
    public bool _empty = false;

    public void SetWord(string word){_word = word;}
    public string GetWord(){return _word;}
    public void MakeEmpty(){
        var builder = new StringBuilder();
        foreach(var c in _word){
            builder.Append('_');
        }
        _word = builder.ToString();
        _empty = true;
    }
    public bool GetEmpty(){return _empty;}
}