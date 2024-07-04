class OpenRoom : StoreRoom {
    private string _name;
    private string _location;
    private int _capacity;
    private double _avgTemp; //F
    private double _humidity;
    public bool _covered;
    private List<StorageItem> _storedItems;

    public OpenRoom(string name,string location,int capacity,double avgTemp,double humidity,bool covered) : base(name,location,capacity,avgTemp){
        _name = name;
        _location = location;
        _capacity = capacity;
        _avgTemp = avgTemp;
        _humidity = humidity;
        _covered = covered;
    }
}