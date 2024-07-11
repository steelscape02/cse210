class ClothingItem : StorageItem{
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private string _style;
    public string Style
    {
        get{return _style;}
        set{_style = value;}
    }
    private Person _assignedPerson;
    public Person AssignedPerson
    {
        get{return _assignedPerson;}
        set{_assignedPerson = value;}
    }
    private string _size;
    public string Size
    {
        get{return _size;}
        set{_size = value;}
    }
    private StoreRoom _storeRoom;
    public StoreRoom StoreRoom
    {
        get{return _storeRoom;}
        set{_storeRoom = value;}
    }
    private static List<ClothingItem> _clothingItems = [];
    public static List<ClothingItem> ClothingItems
    {
        get{return _clothingItems;}
        set{_clothingItems = value;}
    }

    public ClothingItem(string type,StoreRoom storeRoom,string style,Person person,string size){
        _name = type;
        _style = style;
        _assignedPerson = person;
        _size = size;
        _storeRoom = storeRoom;
        ClothingItems.Add(this);
    }

    public static void CreateClothingItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter clothing type (ex: shirt, pant, jacket): ");
        string type = Console.ReadLine();
        StoreRoom storeRoom = StoreRoom.GetStoreRoom(entry:true);
        Console.Write("Enter clothing style (ex: short or long sleeve,fleece, wool): ");
        string style = Console.ReadLine();
        Person assignedPerson = Person.GetPerson();
        Console.Write("Enter clothing size (ex: 32x32, Large): ");
        string size = Console.ReadLine();
        new ClothingItem(type: type, storeRoom: storeRoom,style: style,person: assignedPerson, size: size);
    }

    public static bool RemoveClothingItem()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter clothing type (ex: shirt, pant, jacket): ");
        string type = Console.ReadLine();
        foreach(ClothingItem clothing in ClothingItems)
        {
            if(clothing.Name == type)
            {
                clothing.GetSummary();
                Console.WriteLine();
                Console.Write("Is this the correct item? (y/n): ");
                string choice = Console.ReadLine();
                if(choice.ToLower() == "y"){return ClothingItems.Remove(clothing);}
            }
        }
        Console.Write("\nItem not found. Re-enter name? (y/n): ");
        string response = Console.ReadLine();
        if(response.ToLower() == "y"){RemoveClothingItem();}
        return false;
    }
    
    public static bool EditClothingItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter the desired Clothing name (or enter 'all' to see all items): ");
        string name = Console.ReadLine();
        if(name.ToLower() == "all"){
            for(int i=0;i<ClothingItems.Count();i++){
                Console.WriteLine($"{i}. {ClothingItems[i].Name}");
            }
            Console.WriteLine("\nPlease select desired item number (or enter 'exit' to leave): ");
            name = Console.ReadLine();
            if(name == "exit"){return false;}
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        foreach(ClothingItem clothing in ClothingItems){
            if(clothing.Name == name){
                Console.WriteLine("Edit Wizard\n");

                Console.Write($"Enter new name (Current: {clothing.Name}) (Press enter to keep): )");
                string newName = Console.ReadLine();

                Console.Write($"Enter store room name (Current: {clothing.StoreRoom.Name}) (Press enter to keep): ");
                string newStoreRoom = Console.ReadLine();

                Console.Write($"Enter assigned person (Current: {clothing.AssignedPerson}) (Press enter to keep): ");
                string personName = Console.ReadLine();
                Person assignedPerson = Person.GetPerson(name:personName);

                Console.Write($"Enter style (Current: {clothing.Style}) (Press enter to keep): ");
                string newStyle = Console.ReadLine();

                Console.WriteLine($"Enter clothing size (Current: {clothing.Size}) (Press enter to keep): ");
                string newSize = Console.ReadLine();

                if(assignedPerson != null){clothing.AssignedPerson = assignedPerson;}
                if(newName != null){clothing.Name = newName;}
                if(newStoreRoom != null){clothing.StoreRoom = StoreRoom.GetStoreRoom(newStoreRoom);}
                if(newStyle != null){clothing.Style = newStyle;}
                if(newSize !=  null){clothing.Size = newSize;}
                return true;
            }
        }
        return false;
    }

    public override string GetSummary()
    {
        string summary = @$"
            Name: {_name}\n
            Type: Clothing\n
            Store Room: {_storeRoom.Name}\n\n

            Person: {_assignedPerson.Name}\n
            Size: {_size}\n
            Style: {_style}\n";
        return summary;
    }
}