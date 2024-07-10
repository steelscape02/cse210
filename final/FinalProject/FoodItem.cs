class FoodItem : StorageItem{
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private int _quantity;
    public int Quantity
    {
        get{return _quantity;}
        set{_quantity = value;}
    }
    private StoreRoom _storeRoom;
    public StoreRoom StoreRoom
    {
        get{return _storeRoom;}
        set{_storeRoom = value;}
    }
    private DateTime _expirationDate;
    public DateTime ExpirationDate
    {
        get{return _expirationDate;}
        set{_expirationDate = value;}
    }
    private static List<FoodItem> _foodItems;
    public static List<FoodItem> FoodItems
    {
        get{return _foodItems;}
        set{_foodItems = value;}
    }
    public static List<FoodItem> GetFood(){return FoodItems;}

    
    public FoodItem(string name,int quantity,StoreRoom storeRoom,DateTime expDate){
        _name = name;
        _expirationDate = expDate;
        _quantity = quantity;
        _storeRoom = storeRoom;
        FoodItems.Add(this);
    }
    public override string GetSummary()
    {
        string summary = @$"
            Name: {_name}\n
            Type: Food\n
            Store Room: {_storeRoom.Name}\n\n

            Quantity: {_quantity}\n
            Expiration Date: {_expirationDate}\n";
        return summary;
    }
}