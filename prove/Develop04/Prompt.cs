class Prompt{
    private string _prompt;
    private string _response;
    private bool _used;
    private List<string> _reflectionPrompts;
    private List<string> _reflectionQuestions;
    private List<string> _listingPrompts;

    public void SetLists(){
        //static set
        _reflectionPrompts.Add("Think of a time you stood up for someone else.");
        _reflectionPrompts.Add("Think of a time when you did something really difficult");
        _reflectionPrompts.Add("Think of a time when you helped someone in need");
        _reflectionPrompts.Add("Think of a time when you did something truly selfless");

        _reflectionQuestions.Add("What was this experience meaningful to you?");
        _reflectionQuestions.Add("Have yo ever done anything like this before?");
        _reflectionQuestions.Add("How did you get started?");
        _reflectionQuestions.Add("How did you feel when it was completed?");
        _reflectionQuestions.Add("What made this time different than other times when you were not as successful?");
        _reflectionQuestions.Add("What is your favorite thing about this experience?");
        _reflectionQuestions.Add("What could you learn from this experience that applies to other situations?");
        _reflectionQuestions.Add("What did you learn about yourself through this experience?");
        _reflectionQuestions.Add("How can you keep this experience in mind in the future?");

        _listingPrompts.Add("Who are people that you appreciate?");
        _listingPrompts.Add("What are some personal strengths of yours?");
        _listingPrompts.Add("Who are some people who have helped you this week?");
        _listingPrompts.Add("When have you felt the Holy Ghost this month?");
        _listingPrompts.Add("Who are some of your personal heroes?");
    }

    public string GetPrompt(string activity){ //get and set prompt
        SetLists(); //as a backup
        var rand = new Random();
        int length;
        int pos;
        string prompt;
        switch(activity){
            case "reflection":
                length = _reflectionPrompts.Count();
                pos = rand.Next(length);
                prompt = _reflectionPrompts[pos];
                _prompt = prompt;
                return prompt;
            case "listing":
                length = _listingPrompts.Count();
                pos = rand.Next(length);
                prompt = _listingPrompts[pos];
                _prompt = prompt;
                return prompt;
            default:
                Console.WriteLine("Activity Not Found");
                return "NULL";           
        }
    }

    public string GetResponse(){ //only for listing
        return _response;
    }
}