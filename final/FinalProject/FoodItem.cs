class FoodItem : StorageItem{
    private string _name;
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }
    private int _quantity;
    public int Quantity
    {
        get{return _quantity;}
        set{_quantity = value;}
    }
    private StoreRoom _storeRoom;
    public StoreRoom StoreRoom
    {
        get{return _storeRoom;}
        set{_storeRoom = value;}
    }
    private DateTime _expirationDate;
    public DateTime ExpirationDate
    {
        get{return _expirationDate;}
        set{_expirationDate = value;}
    }
    private static List<FoodItem> _foodItems = [];
    public static List<FoodItem> FoodItems
    {
        get{return _foodItems;}
        set{_foodItems = value;}
    }
    public static List<FoodItem> GetFood(){return FoodItems;}

    
    public FoodItem(string name,int quantity,StoreRoom storeRoom,DateTime expDate){
        _name = name;
        _expirationDate = expDate;
        _quantity = quantity;
        _storeRoom = storeRoom;
        FoodItems.Add(this);
    }

    public static void CreateFoodItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();
        Console.Write("Enter food quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        StoreRoom storeRoom = StoreRoom.GetStoreRoom(entry:true);
        Console.Write("Enter earliest expiration date: ");
        string expDate = Console.ReadLine();
        DateTime parse = ParseDate(expDate);

        _ = new FoodItem(name, quantity, storeRoom, parse );
    }

    public static bool RemoveFoodItem(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();
        foreach(FoodItem food in FoodItems)
        {
            if(food.Name == name){return FoodItems.Remove(food);}
        }
        Console.Write("\nItem not found. Re-enter name? (y/n): ");
        string response = Console.ReadLine();
        if(response.ToLower() == "y"){RemoveFoodItem();}
        return false;
    }

    public static bool EditFoodItem(bool QtyOnly = false){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Enter the desired food name (or enter 'all' to see all items): ");
        string name = Console.ReadLine();
        if(name.ToLower() == "all"){
            if(FoodItems.Count() == 0){
                Console.WriteLine("No items available, returning to main menu");
                Thread.Sleep(200);
                return false;
            }
            for(int i=0;i<FoodItems.Count();i++){
                Console.WriteLine($"{i}. {FoodItems[i].Name}");
            }
            Console.Write("\nPlease select desired item number (or enter 'exit' to leave): ");
            name = Console.ReadLine();
            if(name == "exit"){return false;}
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        foreach(FoodItem food in FoodItems){
            if(food.Name == name){
                if(QtyOnly == true){
                    Console.Write("Enter the number of items to add: ");
                    int updateQty = Convert.ToInt32(Console.ReadLine());
                    food.Quantity += updateQty;
                    return true;
                }else{
                    Console.WriteLine("Edit Wizard\n");
                    Console.Write($"Enter new name (Current: {food.Name}) (Press enter to keep): )");
                    string newName = Console.ReadLine();
                    Console.Write($"Enter new quantity (Current: {food.Quantity}) (Press enter to keep): ");
                    int newQty = 0;
                    try{newQty = Convert.ToInt32(Console.ReadLine());}catch(FormatException){}
                    Console.Write($"Enter store room name (Current: {food.StoreRoom.Name}) (Press enter to keep): ");
                    string newStoreRoom = Console.ReadLine();
                    Console.Write($"Enter earliest expiration date (Current: {food.ExpirationDate}) (Press enter to keep): ");
                    string newExpDate = Console.ReadLine();
                    if(newName != ""){food.Name = newName;}
                    if(newQty != 0){food.Quantity = newQty;}
                    if(newStoreRoom != null){food.StoreRoom = StoreRoom.GetStoreRoom(newStoreRoom);}
                    if(newExpDate != ""){food.ExpirationDate = DateTime.Parse(newExpDate);}
                    return true;
                }
            }
        }
        return false;
    }

    public static FoodItem GetFoodItem(string name){
        foreach(FoodItem food in FoodItems){
            if(food.Name == name){return food;}
        }
        return null;
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