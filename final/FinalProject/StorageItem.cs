abstract class StorageItem{
    private string _name;
    private string _type;
    private StoreRoom _storeRoom;
    private int _quantity;

    //GetSummary
    public virtual string GetSummary(){
        string summary = @$"
            Name: {_name}\n
            Type: N/A\n
            Store Room: {_storeRoom.Name}\n\n
            
            Quantity: {_quantity}\n";
        return summary;
    }
    public virtual string GetAlarmItems(){
        return null;
    }
    //Display
    protected static DateTime ParseDate(string date){
        DateTime parsed = DateTime.Parse(date);
        return parsed;
    }

    
    
}
