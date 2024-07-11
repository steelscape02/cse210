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
    private static List<DocumentItem> _documentItems = [];
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

    public static void CreateDocumentItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter document name: ");
        string name = Console.ReadLine(); 
        Console.Write("Enter document type (ex: Legal, Insurance Information)");
        string type = Console.ReadLine();
        StoreRoom storeRoom = StoreRoom.GetStoreRoom(entry:true);
        Console.Write("Enter earliest expiration date: ");
        string expDate = Console.ReadLine();
        DateTime parse = ParseDate(expDate);
        Person assignedPerson = Person.GetPerson();

        new DocumentItem(name: name,storeRoom: storeRoom,type: type, person: assignedPerson,effectiveDate: parse);
    }

    public static bool RemoveDocumentItem()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter document name: ");
        string name = Console.ReadLine();
        foreach(DocumentItem document in DocumentItems)
        {
            if(document.Name == name){return DocumentItems.Remove(document);}
        }
        Console.Write("\nItem not found. Re-enter name? (y/n): ");
        string response = Console.ReadLine();
        if(response.ToLower() == "y"){RemoveDocumentItem();}
        return false;
    }

    public static bool EditDocumentItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter the desired Document name (or enter 'all' to see all items): ");
        string name = Console.ReadLine();
        if(name.ToLower() == "all"){
            for(int i=0;i<DocumentItems.Count();i++){
                Console.WriteLine($"{i}. {DocumentItems[i].Name}");
            }
            Console.WriteLine("\nPlease select desired item number (or enter 'exit' to leave): ");
            name = Console.ReadLine();
            if(name == "exit"){return false;}
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        foreach(DocumentItem document in DocumentItems){
            if(document.Name == name){
                Console.WriteLine("Edit Wizard\n");
                Console.Write($"Enter new name (Current: {document.Name}) (Press enter to keep): )");
                string newName = Console.ReadLine();
                Console.Write($"Enter store room name (Current: {document.StoreRoom.Name}) (Press enter to keep): ");
                string newStoreRoom = Console.ReadLine();
                Console.Write($"Enter document type (Current: {document.Type}) (Press enter to keep): ");
                string newType = Console.ReadLine();
                Console.Write($"Enter assigned person (Current: {document._assignedPerson.Name}) (Press enter to keep): ");
                string personName = Console.ReadLine();
                Console.Write($"Enter effective date (Current: {document.EffectiveDate}) (Press enter to keep): ");
                string newEffDate = Console.ReadLine();

                Person assignedPerson = Person.GetPerson(name:personName);
                if(assignedPerson != null){document.AssignedPerson = assignedPerson;}
                if(newName != null){document.Name = newName;}
                if(newStoreRoom != null){document.StoreRoom = StoreRoom.GetStoreRoom(newStoreRoom);}
                if(newType != null){document.Type = newType;}
                if(newEffDate != null){document.EffectiveDate = DateTime.Parse(newEffDate);}
                return true;
            }
        }
        return false;
    }
}