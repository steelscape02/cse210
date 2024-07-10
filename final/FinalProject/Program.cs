
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
    public int ClSize = 0;
    public int ClW = 0;
    public int ClL = 0;
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
    
    private static Action NonStaticDelegate;

    static void Load(){
        //JSON
        using (StreamReader r = new StreamReader(FILENAME))
        {
            string json = r.ReadToEnd();
            dynamic array = JsonSerializer.Deserialize<List<ReaderItem>>(json);
            foreach(ReaderItem item in array){
                string type = item.type;
                if(type.ToLower() == "food"){new FoodItem(item.name,item.quantity,item.storeRoom,DateTime.Parse(item.date));}
                if(type.ToLower() == "document"){new DocumentItem(item.name,item.storeRoom,item.docPurpose,item.person,DateTime.Parse(item.date));}
                if(type.ToLower() == "clothing"){new ClothingItem(item.name,item.storeRoom,item.ClStyle,item.person,item.ClW,item.ClL,item.ClSize);}
            }
        }
    }
    
    static async void Write(List<ReaderItem> items,List<ReaderPerson> family){
        //items
        await using FileStream createStream = File.Create(FILENAME);
        foreach(ReaderItem item in items){
            await JsonSerializer.SerializeAsync(createStream,item);
        }
        foreach(ReaderPerson person in family){
            await JsonSerializer.SerializeAsync(createStream,person);
        }
    }

    static void CloseProgram(int flags = 0){
        Program.NonStaticDelegate();
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Closing..");
        Thread.Sleep(400);

        List<ReaderItem> itemList = [];
        foreach(FoodItem food in FoodItem.FoodItems){itemList.Add(new ReaderItem {name=food.Name,quantity=food.Quantity,type="food",storeRoom=food.StoreRoom,date=food.ExpirationDate.ToString()});}
        foreach(DocumentItem document in DocumentItem.DocumentItems){itemList.Add(new ReaderItem {name=document.Name,type="document",storeRoom=document.StoreRoom,date=document.EffectiveDate.ToString(),docPurpose=document.Type,person=document.AssignedPerson});}
        foreach(ClothingItem clothing in ClothingItem.ClothingItems){itemList.Add(new ReaderItem {name=clothing.Name,type="clothing",storeRoom=clothing.StoreRoom,person=clothing.AssignedPerson,ClStyle=clothing.Style,ClSize=clothing.Size,ClL=clothing.Length,ClW=clothing.Width});}
        
        List<ReaderPerson> familyList = [];
        foreach(Person person in Person.Family){familyList.Add(new ReaderPerson {name=person.Name,age=person.Age,gender=person.Gender,height=person.Height,weight=person.Weight,size=person.Size,length=person.Length,width=person.Width});}
        Write(itemList,familyList);
        return;
    }

    static int[] Menu(bool first = false){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("1. Items");
        Console.WriteLine("2. Family");
        Console.WriteLine("3. Reports\n");
        Console.Write("Enter Choice: ");
        int category = Convert.ToInt32(Console.ReadLine());
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

    static void ItemWizard(string type,[Range(1,3)]int option){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        if(option == 1){Console.WriteLine();}
    }

    static void Main(string[] args)
    {
        int[] choice = Menu(); //0: type 1: option
        if(choice[1] == 4){CloseProgram();}

    }
}