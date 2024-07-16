class Person{
    private static List<Person> _family = [];
    public static List<Person> Family
    {
        get{return _family;}
        set{_family = value;}
    }

    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _gender;
    public string Gender
    {
        get{return _gender;}
        set{_gender = value;}
    }
    private int _age;
    public int Age
    {
        get{return _age;}
        set{_age = value;}
    }
    private double _height; //inches
    public double Height
    {
        get{return _height;}
        set{_height = value;}
    }
    private double _weight;
    public double Weight
    {
        get{return _weight;}
        set{_weight = value;}
    }
    private int _size;
    public int Size
    {
        get{return _size;}
        set{_size = value;}
    }
    private int _width;
    public int Width
    {
        get{return _width;}
        set{_width = value;}
    }
    private int _length;
    public int Length
    {
        get{return _length;}
        set{_length = value;}
    }


    //calc given age,weight,and height
    private double _caloric;
    private double _hydration;

    //supply levels
    private int _prepLength = 3; //for 72h (In days)
    private int _pantsNeed = 2;
    private int _shirtsNeed = 3;
    private double _caloricNeed;
    private double _hydrationNeed;

    private int _pants;
    private int _shirts;
    private double _calories;
    private double _water;

    private bool _documentResponsible;


    public Person(string name,string gender,int age,double height,double weight){
        _name = name;
        _gender = gender;
        _age = age;
        _height = height;
        _weight = weight;
        if(gender.ToLower() == "male"){
            _caloric = 66 + (13.7*(weight/2.205)) + (5*(height*2.54)) - (6.8*age);
        }
        if(gender.ToLower() == "female"){
            _caloric = 655 + (9.6*(weight/2.205)) + (1.8*(height*2.54)) - (4.7*age);
        }
        _hydration = weight * (2/3);
        _hydration = _hydration * _prepLength;
        _caloricNeed = _caloric * _prepLength;
    }

    public static void CreatePerson(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter biological sex at birth (male / female): ");
        string gender = Console.ReadLine();
        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter height (decimal notation: 5 ft 6 in -> 5.5): ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter weight (decimals allowed): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Family.Add(new Person(name: name, gender: gender, age: age, height: height, weight: weight));
    }

    public static bool RemovePerson(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        return Family.Remove(GetPerson(entry:true));
    }

    public static bool EditPerson(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Person person = GetPerson(entry:true);
        if(person != null){ //If person exists, enter edit wizard
            Console.Write($"Enter name (Current: {person.Name}) (Press enter to keep): ");
            string newName = Console.ReadLine();
            Console.Write($"Enter biological sex at birth (Current: {person.Gender}) (Press enter to keep): ");
            string newGender = Console.ReadLine();
            Console.Write($"Enter age (Current: {person.Age}) (Press enter to keep): ");
            int newAge = 0;
            try{newAge = Convert.ToInt32(Console.ReadLine());}catch(FormatException){}
            Console.Write($"Enter height (Current: {person.Height} in) (Press enter to keep): ");
            double newHeight = 0.0;
            try{newHeight = Convert.ToDouble(Console.ReadLine());}catch(FormatException){}
            Console.Write($"Enter weight (Current: {person.Weight} lbs) (Press enter to keep): ");
            double newWeight = 0.0;
            try{newWeight = Convert.ToDouble(Console.ReadLine());}catch(FormatException){}
            //check for null
            if(newName != ""){person.Name = newName;}
            if(newGender != ""){person.Gender = newGender;}
            if(newAge != 0){person.Age = newAge;}
            if(newHeight != 0.0){person.Height = newHeight;}
            if(newWeight != 0.0){person.Weight = newWeight;}
            return true;
        }
        return false;
    }

    public static Person GetPerson(string name = "",bool entry = false){
        if(entry == true){
            Console.Write("Enter the name of the person: ");
            name = Console.ReadLine();
        }
        foreach(Person person in Family){
            if(person.Name == name){return person;}
        }
        if(entry == true){
            Console.WriteLine("Person not found..");
            Console.Write("Search again? (y/n): ");
            string exitOption = Console.ReadLine();
            if(exitOption.ToLower() == "y"){GetPerson(entry:true);}
        }
        return null;
    }
    public string GetSummary(){
        var summary = new System.Text.StringBuilder();
        summary.AppendLine("Family: \n");

        foreach(Person person in _family){
            summary.AppendLine(@$"
                Name: {person._name}\n
                Gender: {person._gender}\n
                Age: {person._age}\n
                Height: {person._height} Weight: {person._weight}\n\n
                
                Caloric Requirement (1 day): {person._caloric}\n
                Water Requirement (1 day): {person._hydration}\n");
        }

        return summary.ToString();
    }

    public bool SufficientSupply(string name){
        foreach(Person person in _family){
            if(person._name == name){
                if(person._shirtsNeed >= person._shirts
                    && person._pantsNeed >= person._pants
                    && person._caloricNeed >= person._calories
                    && person._hydrationNeed >= person._water)
                    {return true;}
                    else{return false;}
            }
        }
        return false;
    }

}