class ClothingItem : StorageItem{
    private string _name;
    private string _style;
    private Person _assignedPerson;
    private int _width;
    private int _length;
    private int _size;
    private StoreRoom _storeRoom;

    public ClothingItem(string name,StoreRoom storeRoom,string style,Person person,int width,int length,int size) : base(name,1,"Clothing",storeRoom,null){
        _name = name;
        _style = style;
        _assignedPerson = person;
        _width = width;
        _length = length;
        _size = size;
        _storeRoom = storeRoom;
    }
    public override string GetSummary()
    {
        string summary;
        if(_width > 0 && _length > 0){
            summary = @$"
                Name: {_name}\n
                Type: Clothing\n
                Store Room: {_storeRoom.Name}\n\n

                Person: {_assignedPerson.Name}\n
                Size: W: {_width} L: {_length}\n
                Style: {_style}\n";
        }else{
            summary = @$"
                Name: {_name}\n
                Type: Clothing\n
                Store Room: {_storeRoom.Name}\n\n

                Person: {_assignedPerson.Name}\n
                Size: {_size}\n
                Style: {_style}\n";
        }
        return summary;
    }
}