class FoodItem : StorageItem{
    private string _name;
    private DateTime _expirationDate;
    private int _quantity;
    private StoreRoom _storeRoom;
    
    public FoodItem(string name,int quantity,StoreRoom storeRoom,DateTime expDate) : base(name,quantity,"Food",storeRoom,expDate.ToString()){
        _name = name;
        _expirationDate = expDate;
        _quantity = quantity;
        _storeRoom = storeRoom;
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