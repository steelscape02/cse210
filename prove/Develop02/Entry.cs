class Entry(){
    public string _date = DateTime.Now.ToString("M/d/yyyy");
    public string _response;
    
    public string _prompt;
    public List<string> _prompts = [
        "Who was the most interesting person I interacted with today? ",
        "What was the best part of my day? ",
        "How did I see the hand of the Lord in my life today? ",
        "What was the strongest emotion I felt today? ",
        "If I had one thing I could do over today, what would it be? "
    ];
    public void PromptUser(){
        Random rnd = new();
        _prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.Write(_prompt);
        _response = Console.ReadLine();
    }
}