class Prompt{
    private string _prompt;
    private string _question;
    private string _response;
    private List<string> _reflectionPrompts = [""];
    private List<string> _reflectionQuestions = [""];
    private List<string> _listingQuestions = [""];

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

        _listingQuestions.Add("Who are people that you appreciate?");
        _listingQuestions.Add("What are some personal strengths of yours?");
        _listingQuestions.Add("Who are some people who have helped you this week?");
        _listingQuestions.Add("When have you felt the Holy Ghost this month?");
        _listingQuestions.Add("Who are some of your personal heroes?");
    }

    public string GetPrompt(string activity){ //get and set prompt
         //as a backup
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
            default:
                Console.WriteLine("Activity Not Found");
                return "NULL";           
        }
    }

    public string GetQuestion(string activity){ //get and set question
        var rand = new Random();
        int length;
        int pos;
        string question;
        switch(activity){
            case "reflection":
                length = _reflectionQuestions.Count();
                pos = rand.Next(length);
                question = _reflectionQuestions[pos];
                _question = question;
                return question;
            case "listing":
                length = _listingQuestions.Count();
                pos = rand.Next(length);
                question = _listingQuestions[pos];
                _question = question;
                return question;
            default:
                Console.WriteLine("Activity Not Found");
                return "NULL";
        }
    }

    public void SetResponse(string response){
        _response = response;
    }
    public string GetResponse(){ //only for listing
        return _response;
    }
}