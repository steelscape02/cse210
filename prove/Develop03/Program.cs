using System;

class Program
{
    static void Main(string[] args)
    {
        
        Scripture thing1 = new();
        string nephi37 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        thing1.SetPhrase("1 Nephi 3:7",nephi37);
        bool proceed = false;
        Scripture thing2 = new();
        string nephi225 = "Adam fell that men might be; and men are, that they might have joy.";
        thing2.SetPhrase("2 Nephi 2:25",nephi225);
        thing1.Display();
        while(thing1.GetLength() > 0){
            Console.ReadKey();
            proceed = thing1.Advance();
            if(proceed == false){thing1.Display();}else{thing1.Finish();break;}
        }
    }
}

