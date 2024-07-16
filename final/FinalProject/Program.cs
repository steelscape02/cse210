
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

internal class ReaderItem{
    public string name;
    public int quantity = 1;
    public string type;
    public StoreRoom storeRoom;
    public string date;
    public string docPurpose = "";
    public string ClStyle = "";
    public string ClSize = "";
    public Person person;

}

internal class ReaderPerson{
    public string name;

    public int age;
    public string gender;
    public double height;
    public double weight;
    public int size;
    public int width;
    public int length;
}

class Program
{
    static readonly string FILENAME = "db.json";

    static void Load()
    {
        try{
            using (StreamReader r = new StreamReader(FILENAME))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonSerializer.Deserialize<List<ReaderItem>>(json);
                foreach(ReaderItem item in array){
                    string type = item.type;
                    if(type.ToLower() == "food"){new FoodItem(item.name,item.quantity,item.storeRoom,DateTime.Parse(item.date));}
                    if(type.ToLower() == "document"){new DocumentItem(item.name,item.storeRoom,item.docPurpose,item.person,DateTime.Parse(item.date));}
                    if(type.ToLower() == "clothing"){new ClothingItem(item.name,item.storeRoom,item.ClStyle,item.person,item.ClSize);}
                    //TODO: #1 Add StoreRoom info
                }
            }
        }catch(FileNotFoundException){
            return;
        }
    }

    static async void Write(List<ReaderItem> items,List<ReaderPerson> family)
    {
        //items
        await using FileStream createStream = File.Create(FILENAME);
        foreach(ReaderItem item in items){
            await JsonSerializer.SerializeAsync(createStream,item);
        }
        foreach(ReaderPerson person in family){
            await JsonSerializer.SerializeAsync(createStream,person);
        }
    }

    static void CloseProgram(int flags = 0)
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Closing..");
        Thread.Sleep(400);

        List<ReaderItem> itemList = [];
        foreach(FoodItem food in FoodItem.FoodItems){itemList.Add(new ReaderItem {name=food.Name,quantity=food.Quantity,type="food",storeRoom=food.StoreRoom,date=food.ExpirationDate.ToString()});}
        foreach(DocumentItem document in DocumentItem.DocumentItems){itemList.Add(new ReaderItem {name=document.Name,type="document",storeRoom=document.StoreRoom,date=document.EffectiveDate.ToString(),docPurpose=document.Type,person=document.AssignedPerson});}
        foreach(ClothingItem clothing in ClothingItem.ClothingItems){itemList.Add(new ReaderItem {name=clothing.Name,type="clothing",storeRoom=clothing.StoreRoom,person=clothing.AssignedPerson,ClStyle=clothing.Style,ClSize=clothing.Size});}
        
        List<ReaderPerson> familyList = [];
        foreach(Person person in Person.Family){familyList.Add(new ReaderPerson {name=person.Name,age=person.Age,gender=person.Gender,height=person.Height,weight=person.Weight,size=person.Size,length=person.Length,width=person.Width});}
        Write(itemList,familyList);
        return;
    }

    static int[] Menu(bool first = false)
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("1. Items");
        Console.WriteLine("2. Family");
        Console.WriteLine("3. Reports");
        Console.WriteLine("4. Quit\n");
        Console.Write("Enter Choice: ");
        int category = 0;
        try{category = Convert.ToInt32(Console.ReadLine());}catch(FormatException)
        {
            Console.WriteLine("Please enter a number..");
            Thread.Sleep(600);
            Menu();
        }
        if(category == 4){return [4,0];}
        int option = 0;
        if(category == 1 || category == 2){ //items or family
            Console.Clear();
            Console.SetCursorPosition(0,0);
            if(category == 1){Console.WriteLine("Items\n");}
            else{Console.WriteLine("Family\n");}
            Console.WriteLine("1. New");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Go back\n");
            Console.Write("Enter Choice: ");
            option = Convert.ToInt32(Console.ReadLine());
        }
        if(category == 3){ //reports
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("Reports\n");
            Console.WriteLine("1. Show all");
            Console.WriteLine("2. Configure Default Display");
            Console.WriteLine("3. Custom Report");
            Console.WriteLine("4. Go back\n");
            Console.Write("Enter Choice: ");
            option = Convert.ToInt32(Console.ReadLine());
        }
        return [category,option];
    }

    static void ItemWizard([Range(1,3)]int option)
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Please select item type: \n");
        Console.WriteLine("1. Food");
        Console.WriteLine("2. Clothing");
        Console.WriteLine("3. Document");
        Console.WriteLine("4. Back to Menu\n");

        Console.Write("Please enter item type number: ");
        int itemType = Convert.ToInt32(Console.ReadLine());
        if(itemType == 4){Main([""]);}

        if(option ==1) //New
        {
            if(itemType == 1){FoodItem.CreateFoodItem();}
            if(itemType == 2){ClothingItem.CreateClothingItem();}
            if(itemType == 3){DocumentItem.CreateDocumentItem();}
        }
        if(option ==2) //Edit
        {
            if(itemType == 1)
            {
                Console.WriteLine("Select Option");
                Console.WriteLine("1. Update Quantity only");
                Console.WriteLine("2. Edit item\n");
                Console.Write("Enter option number: ");
                int foodChoice = Convert.ToInt32(Console.ReadLine());
                FoodItem.EditFoodItem(foodChoice == 1 ? true : false); //for QtyOnly parameter
            }
            if(itemType == 2){ClothingItem.EditClothingItem();}
            if(itemType == 3){DocumentItem.EditDocumentItem();}
        }
        if(option == 3) //Remove
        {
            if(itemType == 1){FoodItem.RemoveFoodItem();}
            if(itemType == 2){ClothingItem.RemoveClothingItem();}
            if(itemType == 3){DocumentItem.RemoveDocumentItem();}
        }
    }

    static void PersonWizard([Range(1,3)]int option)
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        if(option ==1) //New
        {Person.CreatePerson();}
        if(option ==2) //Edit
        {Person.EditPerson();}
        if(option ==3) //Remove
        {Person.RemovePerson();}
    }

    

    static void Main(string[] args)
    {
        Load();
        bool exit = false;
        while(exit == false){
            int[] choice = Menu(); //0: type 1: option
            if(choice[1] == 4 || choice[0] == 4) //Go back option
            {
                CloseProgram();
                exit = true;
            }
            if(choice[0] == 1) //Item
            {
                ItemWizard(choice[1]);
            }
            if(choice[0] == 2) //Family
            {
                PersonWizard(choice[1]);
            }
        }

    }
}