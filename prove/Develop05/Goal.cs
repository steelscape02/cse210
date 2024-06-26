class Goal{
    private static List<Goal> _goals = [];

    private int _totalPoints;
    private int _points;
    private bool _completed;
    private string _name;
    private string _type;
    private DateTime _date;
    

    public Goal(string name,bool completed,DateTime date, string type){
        _name = name;
        _date = date;
        _type = type;
        _completed = completed;
        _goals.Add(this);
    }

    public virtual int GetPoints(){return _totalPoints;}

    public new string GetType(){return _type;}
    public string GetName(){return _name;}

    public static int Display(){
        int total = 0;
        foreach(Goal goal in _goals){
            if(goal._type == "Simple"){if(goal._completed == true){total += goal._points;}}
            else{total += goal._points;}
            string completionDialog;
            if(goal._type == "CheckList"){
                CheckListGoal check = CheckListGoal.FindCheckListGoal(goal._name);
                int remReps = check.GetReps();
                int totReps = check.GetTotalReps();
                completionDialog = $"{totReps - remReps}/{totReps}";
            }
            else if(goal._completed == true){completionDialog = "X";}
            else{completionDialog = " ";}

            Console.WriteLine($"Goal Type: {goal._type}\nPoints awarded: {goal._points}\nStarted on: {goal._date}\nCompleted: [{completionDialog}]\n");
        }
        if(_goals.Count() > 0){
            Console.WriteLine($"Total Points Gained: {total}");
            Console.Write("Press any key to go back...");
            Console.ReadKey();
        }else{
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("No goals available");
        }
        return _goals.Count();
    }
    public static int DisplayExisting(bool all = false){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._completed == false || all == true){Console.WriteLine($"{i+1}.\nName: {_goals[i]._name}\nType: {_goals[i]._type}\n");}
        }
        return _goals.Count();
    }
    public static Goal FindGoal(int index){
        try{
            Goal goal = _goals[index-1];
            return goal;
        }catch(ArgumentOutOfRangeException){
            Console.WriteLine($"Index not found\n");
            return null;
        }
    }
    public static bool RemoveGoal(int index){
        try{
            Goal goal = _goals[index-1];
            _goals.Remove(goal);
            return true;
        }catch(ArgumentOutOfRangeException){
            Console.WriteLine($"Index not found\n");
            return false;
        }
    }

    public virtual void CloseGoal(){UpdateTotal(_totalPoints);_goals.Remove(this);} //goal closure is slightly different in each class

    protected void CompleteGoal(string name, int points){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._completed = true;
                _goals[index]._points = points;
                break;
            }
        }
    }
    protected void UpdatePoints(string name,int points){
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._points = points;
                break;
            }
        }
    }
    protected void UpdateTotal(int points){_totalPoints += points;}
    protected void RemoveGoal(){_goals.Remove(this);}

    public static void Write(){
        string _filename = "goals.txt";
        using StreamWriter sw = new(_filename,false); //false allows overwrite
        int completeStatus;

        foreach(SimpleGoal simple in SimpleGoal.ExportGoals()){
            if(simple.GetComplete() == true){completeStatus = 1;}
            else{completeStatus = 0;}
            sw.WriteLine($"{"Simple"};{simple._name};{completeStatus};{simple._date};{simple.GetReward()}");
            if(simple._completed == true){}
        }
        foreach(EternalGoal eternal in EternalGoal.ExportGoals()){
            if(eternal.GetComplete() == true){completeStatus = 1;}
            else{completeStatus = 0;}
            sw.WriteLine($"{"Eternal"};{eternal._name};{completeStatus};{eternal._date};{eternal.GetFactor()};{eternal.GetRunningTotal()}");
        }
        foreach(CheckListGoal checkList in CheckListGoal.ExportGoals()){
            if(checkList.GetComplete() == true){completeStatus = 1;}
            else{completeStatus = 0;}
            sw.WriteLine($"{"CheckList"};{checkList._name};{completeStatus};{checkList._date};{checkList.GetFactor()};{checkList.GetReps()};{checkList.GetTotalReps()};{checkList.GetReward()};{checkList.GetRunningTotal()}");
        }   
        
    }
    

    public static void Read(){
        string _filename = "goals.txt";
        if(File.Exists(_filename)){
            using StreamReader sr = new StreamReader(_filename);
            string line;
            List<string> names = [];
            while ((line = sr.ReadLine()) != null)
            {
                bool exists = false;
                string[] lineElem = line.Split(";");
                bool complete = false;
                if (Convert.ToInt32(lineElem[2]) == 1) { complete = true; }
                else { complete = false; }
                DateTime date = DateTime.Parse(lineElem[3]);
                foreach(string name in names){if(lineElem[1].ToLower() == name.ToLower()){exists=true;}}
                names.Add(lineElem[1]);
                
                if(exists == false){
                    switch(lineElem[0]){
                        case "Simple":
                            SimpleGoal simple = new(lineElem[1],complete,date,Convert.ToInt32(lineElem[4]));
                            if(complete == true){simple._points = Convert.ToInt32(lineElem[4]);}
                            break;
                        case "Eternal":
                            EternalGoal eternal = new(lineElem[1],complete,date,Convert.ToInt32(lineElem[4]));
                            eternal._points = Convert.ToInt32(lineElem[5]);
                            eternal.SetRunning(Convert.ToInt32(lineElem[5]));
                            break;
                        case "CheckList":
                            CheckListGoal checkList = new(lineElem[1],complete,date,Convert.ToInt32(lineElem[4]),Convert.ToInt32(lineElem[5]),Convert.ToInt32(lineElem[7]));
                            checkList._points = Convert.ToInt32(lineElem[8]);
                            checkList.SetRunning(Convert.ToInt32(lineElem[8]));
                            checkList.SetRepTotal(Convert.ToInt32(lineElem[6]));
                            break;
                    }
                }     
            }
        }else{Console.WriteLine("File Not Found");Thread.Sleep(2000);}
    }
}