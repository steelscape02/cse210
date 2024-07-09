class DocumentItem : StorageItem{
    private string _name;
    private string _type;
    private DateTime _effectiveDate;
    private Person _assignedPerson;
    private StoreRoom _storeRoom;

    public DocumentItem(string name,StoreRoom storeRoom,string type,Person person,DateTime effectiveDate){
        _name = name;
        _type = type;
        _effectiveDate = effectiveDate;
        _assignedPerson = person;
        _storeRoom = storeRoom;
    }
}