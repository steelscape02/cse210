class StoreRoom{
    private List<StoreRoom> _storeRooms;
    private string _name;
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

    public string GetName(){return _name;}
}