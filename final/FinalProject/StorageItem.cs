class StorageItem{
    private string _name;
    private string _type;
    private string _storeRoom; //change to store room type
    private int _quantity;

    public StorageItem(string name,string type,int quantity){
        _name = name;
        _type = type;
        _quantity = quantity;
    }
    //GetSummary
    public virtual string GetSummary(){
        return null;
    }
    public virtual string GetAlarmItems(){
        return null;
    }
    //Display
    
}