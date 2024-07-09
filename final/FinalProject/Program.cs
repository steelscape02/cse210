using System;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class ReaderItem{
    public string name;
    public int quantity;
    public string type;
    public StoreRoom storeRoom;
    public string date;
    public string DocPurpose;
    public string ClStyle;
    public int ClSize;
    public int ClW;
    public int ClL;
    public Person person;

}

internal class ReaderPerson{
    public string name;
}

class Program
{
    string FILENAME = "db.json";
    List<StorageItem> _items;
    //JSON
    void Load(){
        //JSON
        using (StreamReader r = new StreamReader(FILENAME))
        {
            string json = r.ReadToEnd();
            dynamic array = JsonSerializer.Deserialize<List<ReaderItem>>(json);
            foreach(ReaderItem item in array){
                string type = item.type;
                if(type.ToLower() == "food"){_items.Add(new FoodItem(item.name,item.quantity,item.storeRoom,DateTime.Parse(item.date)));}
                if(type.ToLower() == "document"){_items.Add(new DocumentItem(item.name,item.storeRoom,item.DocPurpose,item.person,DateTime.Parse(item.date)));}
                if(type.ToLower() == "clothing"){_items.Add(new ClothingItem(item.name,item.storeRoom,item.ClStyle,item.person,item.ClW,item.ClL,item.ClSize));}
            }
        }
    }
    void LoadPeople(){

    }
    async void Write(List<StorageItem> items,List<Person> family){
        //items
        await using FileStream createStream = File.Create(FILENAME);
        foreach(StorageItem item in items){
            await JsonSerializer.SerializeAsync(createStream,item);
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
    }
}