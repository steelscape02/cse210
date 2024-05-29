using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = [];
        bool proceed = false;
        Scripture thing1 = new();
        string nephi37 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        thing1.SetPhrase("1 Nephi 3:7",nephi37);
        scriptures.Add(thing1);
        Scripture thing2 = new();
        string nephi225 = "Adam fell that men might be; and men are, that they might have joy.";
        thing2.SetPhrase("2 Nephi 2:25",nephi225);
        scriptures.Add(thing2);
        var rand = new Random();
        int index = rand.Next(scriptures.Count);
        Scripture selected = scriptures[index];
        selected.Display();
        while(selected.GetLength() > 0){
            Console.ReadKey();
            proceed = selected.Advance();
            if(proceed == false){selected.Display();}else{selected.Finish();break;}
        }
    }
}

