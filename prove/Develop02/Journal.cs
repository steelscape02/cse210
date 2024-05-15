using System;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;

class Journal(){
    static public List<Entry> _entries = [];

    public void NewEntry(){
        Entry entry = new();
        entry.PromptUser();
        _entries.Add(entry);
    }
    public static void Display(){
        Console.WriteLine("\n\n- Journal -");
        foreach(Entry entry in _entries){
            Console.WriteLine($"\nDate: {entry._date}\nPrompt: {entry._prompt}\nResponse: {entry._response}\nMood: {entry._mood}");
        }
        Console.WriteLine("\n\n");
    }
    public static void Save(){
        string filename;
        Console.Write("Please enter filename: ");
        filename = Console.ReadLine();
        string path = Directory.GetCurrentDirectory();
        
        using StreamWriter outputFile = new(filename);
        foreach (Entry entry in _entries)
            outputFile.WriteLine($"{entry._date};{entry._prompt};{entry._response};{entry._mood}");
    }
    public static void Load(){
        string filename;
        Console.Write("Please enter filename: ");
        filename = Console.ReadLine();
        try
        {
            string path = Directory.GetCurrentDirectory();
            using StreamReader reader = new(filename);;
            
            string line;
            while((line = reader.ReadLine()) != null){
                string[] elements = line.Split(";");
                //Console.WriteLine(elements);
                Entry entry = new()
                {
                    _date = elements[0],
                    _prompt = elements[1],
                    _response = elements[2],
                    _mood = elements[3]
                };
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