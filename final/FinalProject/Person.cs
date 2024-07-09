class Person{
    private List<Person> _family;

    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _gender;
    private int _age;
    private double _height; //inches
    private double _weight;

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