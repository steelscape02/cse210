class ClothingItem : StorageItem{
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _style;
    public string Style
    {
        get{return _style;}
        set{_style = value;}
    }
    private Person _assignedPerson;
    public Person AssignedPerson
    {
        get{return _assignedPerson;}
        set{_assignedPerson = value;}
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
    private int _size;
    public int Size
    {
        get{return _size;}
        set{_size = value;}
    }
    private StoreRoom _storeRoom;
    public StoreRoom StoreRoom
    {
        get{return _storeRoom;}
        set{_storeRoom = value;}
    }
    private static List<ClothingItem> _clothingItems;
    public static List<ClothingItem> ClothingItems
    {
        get{return _clothingItems;}
        set{_clothingItems = value;}
    }

    public ClothingItem(string name,StoreRoom storeRoom,string style,Person person,int width,int length,int size){
        _name = name;
        _style = style;
        _assignedPerson = person;
        _width = width;
        _length = length;
        _size = size;
        _storeRoom = storeRoom;
        ClothingItems.Add(this);
    }
    public override string GetSummary()
    {
        string summary;
        if(_width > 0 && _length > 0){
            summary = @$"
                Name: {_name}\n
                Type: Clothing\n
                Store Room: {_storeRoom.Name}\n\n

                Person: {_assignedPerson.Name}\n
                Size: W: {_width} L: {_length}\n
                Style: {_style}\n";
        }else{
            summary = @$"
                Name: {_name}\n
                Type: Clothing\n
                Store Room: {_storeRoom.Name}\n\n

                Person: {_assignedPerson.Name}\n
                Size: {_size}\n
                Style: {_style}\n";
        }
        return summary;
    }
}