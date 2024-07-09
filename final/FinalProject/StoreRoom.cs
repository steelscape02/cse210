class StoreRoom{
    private List<StoreRoom> _storeRooms;
    public List<StoreRoom> StoreRooms
    {
        get{return _storeRooms;}
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
    private List<StorageItem> _storedItems;

    public StoreRoom(string name,string location,int capacity,double avgTemp){
        _name = name;
        _location = location;
        _capacity = capacity;
        _avgTemp = avgTemp;
    }

    public StoreRoom GetStoreRoom(string name){
        foreach(StoreRoom room in StoreRooms){
            if(room.Name == name){return room;}
        }
        return null;
    }
}