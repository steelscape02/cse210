using System.Runtime.InteropServices;
using System.Text;

class StorageItem{
    private string _name;
    private string _type;
    private StoreRoom _storeRoom; //change to store room type
    private int _quantity;
    private List<StorageItem> _items;
    public List<StorageItem> Items
    {
        get{return _items;}
        set{_items = value;}
    }


    public StorageItem(string name = "",int quantity = 0,string type = "",StoreRoom storeRoom = null,string date = "",string DocPurpose = "",string ClStyle = "",int ClSize = 0,int ClW = 0,int ClL = 0,Person person = null){
        _name = name;
        _type = type;
        _quantity = quantity;
        _storeRoom = storeRoom;
        if(type.ToLower() == "food"){_items.Add(new FoodItem(name,quantity,storeRoom,DateTime.Parse(date)));}
        if(type.ToLower() == "document"){_items.Add(new DocumentItem(name,storeRoom,DocPurpose,person,DateTime.Parse(date)));}
        if(type.ToLower() == "clothing"){_items.Add(new ClothingItem(name,storeRoom,ClStyle,person,ClW,ClL,ClSize));}
    }
    //GetSummary
    public virtual string GetSummary(){
        string summary = @$"
            Name: {_name}\n
            Type: N/A\n
            Store Room: {_storeRoom.Name}\n\n
            
            Quantity: {_quantity}\n";
        return summary;
    }
    public string DisplaySummary(){
        var summary = new StringBuilder();
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
