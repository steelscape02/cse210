class StoreRoom{
    private static List<StoreRoom> _storeRooms = [];
    public static List<StoreRoom> StoreRooms
    {
        get => _storeRooms;
        set{_storeRooms = value;}
    }
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _location;
    private int _capacity;
    private double _avgTemp; //F
    private static List<ReaderItem> _storedItems;
    public static List<ReaderItem> StoredItems
    {
        get => _storedItems;
        set{_storedItems = value;}
    }

    public StoreRoom(string name,string location,int capacity,double avgTemp){
        _name = name;
        _location = location;
        _capacity = capacity;
        _avgTemp = avgTemp;
        StoreRooms.Add(this);
    }

    public static void CreateStoreRoom(string nameDefault = "",bool overwrite = true){
        if(overwrite == true)
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
        }
        string name;
        if(nameDefault != "")
        {
            Console.Write($"Enter store room name (Default: {nameDefault}) (Press enter to keep): ");
            name = Console.ReadLine();
            if(name == "" || name == null){name = nameDefault;}
        }
        else
        {
            Console.Write("Enter store room name: ");
            name = Console.ReadLine();
        }
        Console.Write("Enter store room location: ");
        string location = Console.ReadLine();
        Console.Write("Enter store room capacity: ");
        int capacity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter average temperature in the store room (in F): ");
        double avgTemp = Convert.ToDouble(Console.ReadLine());
        new StoreRoom(name:name,location:location,capacity:capacity,avgTemp:avgTemp);
        Console.Clear();
        Console.SetCursorPosition(0,0);
    }

    public static StoreRoom GetStoreRoom(string name="",bool entry = false){
        if(entry == true){
            Console.Write("Enter desired store room name: ");
            name = Console.ReadLine();
        }
        foreach(StoreRoom room in StoreRooms){
            if(room.Name == name){return room;}
        }
        if(entry == true){
            Console.WriteLine("Store room not found");
            Console.Write("Create new store room? (y/n): ");
            string choice = Console.ReadLine();

            if(choice == "y"){CreateStoreRoom(nameDefault:name,overwrite:false);}
            else{GetStoreRoom(name:name,entry:true);}
        }
        return null;
    }
}