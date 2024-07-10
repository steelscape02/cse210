class DocumentItem : StorageItem{
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _type;
    public string Type
    {
        get{return _type;}
        set{_type = value;}
    }
    private DateTime _effectiveDate;
    public DateTime EffectiveDate
    {
        get{return _effectiveDate;}
        set{_effectiveDate = value;}
    }
    private Person _assignedPerson;
    public Person AssignedPerson
    {
        get{return _assignedPerson;}
        set{_assignedPerson = value;}
    }
    private StoreRoom _storeRoom;
    public StoreRoom StoreRoom
    {
        get{return _storeRoom;}
        set{_storeRoom = value;}
    }
    private static List<DocumentItem> _documentItems;
    public static List<DocumentItem> DocumentItems
    {
        get{return _documentItems;}
        set{_documentItems = value;}
    }

    public DocumentItem(string name,StoreRoom storeRoom,string type,Person person,DateTime effectiveDate){
        _name = name;
        _type = type;
        _effectiveDate = effectiveDate;
        _assignedPerson = person;
        _storeRoom = storeRoom;
        DocumentItems.Add(this);
    }
}