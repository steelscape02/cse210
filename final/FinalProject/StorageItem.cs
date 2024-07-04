class StorageItem{
    private string _name;
    private StoreRoom _storeRoom; //change to store room type
    private int _quantity;
    private List<StorageItem> _items;

    public StorageItem(string name,int quantity,StoreRoom storeRoom){
        _name = name;
        _quantity = quantity;
        _storeRoom = storeRoom;
    }
    //GetSummary
    public virtual string GetSummary(){
        string summary = @$"
            Name: {_name}\n
            Type: N/A\n
            Store Room: {_storeRoom.GetName()}\n\n
            
            Quantity: {_quantity}\n";
        return summary;
    }
    public string DisplaySummary(){
        var summary = new System.Text.StringBuilder();
        for(int i=0;i<_items.Count();i++){
            _items[i].GetSummary();
        }
        return summary.ToString();
    }
    public virtual string GetAlarmItems(){
        return null;
    }
    //Display
    
}