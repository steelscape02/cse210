using System;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;

class Journal(){
    static public List<Entry> _entries = [];

    public void NewEntry(){
        Entry entry = new Entry();
        entry.PromptUser();
        _entries.Add(entry);
    }
    public void Display(){
        Console.WriteLine("\n\n- Journal -");
        foreach(Entry entry in _entries){
            Console.WriteLine($"\nDate: {entry._date}\nPrompt: {entry._prompt}\nResponse: {entry._response}");
        }
        Console.WriteLine("\n\n");
    }
    public static void Save(){
        string filename;
        Console.Write("Please enter filename: ");
        filename = Console.ReadLine();
        string path = "C:/Users/nicho/Documents/Programming/College/CSE210 - SP24/cse210/prove/Develop02";
        
        using StreamWriter outputFile = new(Path.Combine(path,filename));
        foreach (Entry entry in _entries)
            outputFile.WriteLine($"{entry._date};{entry._prompt};{entry._response}");
    }
    public void Load(){ //DNE
        string filename;
        Console.Write("Please enter filename: ");
        filename = Console.ReadLine();
        try
        {
            string path = "C:/Users/nicho/Documents/Programming/College/CSE210 - SP24/cse210/prove/Develop02";
            using StreamReader reader = new(Path.Combine(path,filename));;
            
            string line;
            while((line = reader.ReadLine()) != null){
                string[] elements = line.Split(";");
                //Console.WriteLine(elements);
                Entry entry = new Entry();
                entry._date = elements[0];
                entry._prompt = elements[1];
                entry._response = elements[2];
                //Console.WriteLine($"Date: {elements[0]}\nPrompt: {elements[1]}\nResponse: {elements[2]}");
                _entries.Add(entry);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message); 
        }
    }
}