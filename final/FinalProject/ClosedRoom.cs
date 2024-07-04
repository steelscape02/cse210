class ClosedRoom : StoreRoom{
    private string _name;
    private string _location;
    private int _capacity;
    private double _avgTemp; //F
    private List<StorageItem> _storedItems;
    public ClosedRoom(string name,string location,int capacity,double avgTemp) : base(name,location,capacity,avgTemp){
        _name = name;
        _location = location;
        _capacity = capacity;
        _avgTemp = avgTemp;
    }
}