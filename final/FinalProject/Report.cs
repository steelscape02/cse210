using System.Security.Cryptography.X509Certificates;

class Report{
    private string _name;
    public string Name{
        get => _name;
        set{_name = value;}
    }
    private string _type;
    public string Type{
        get => _type;
        set{_type = value;}
    }
    private static List<ReaderItem> _items;
    public static List<ReaderItem> Items{
        get => _items;
        set{_items = value;}
    }
    private static List<ReaderPerson> _family;
    public static List<ReaderPerson> Family{
        get => _family;
        set{_family = value;}
    }
    private string _filterOption;
    public string FilterOption{
        get => _filterOption;
        set{_filterOption = value;}
    }
    private static List<Report> _reports;
    public static List<Report> Reports{
        get => _reports;
        set{_reports = value;}
    }
    private static string[] Codes =
    [
        "full",
        "items",
        "family",
        "family+",
        "storage rooms",
        "needs"
    ];


    public Report(string type,List<ReaderItem> items,List<ReaderPerson> family,string filterOption){
        Type = type;
        Items = items;
        Family = family;
        FilterOption = filterOption;
        Reports.Add(this);
    }

    public static Report CreateReport(){ //custom
        
        Console.Clear();
        Console.SetCursorPosition(0,0);
        string type;
        do{
            Console.Write("Enter report type (options: full, items, family, family+, storage rooms, needs): ");
            type = Console.ReadLine();
        }while(! Codes.Any(type.Contains)); //check all substrings
        
        return null;
    }

    public static bool GetReport(){
        Report report = FindReport();
        if(report != null){
            Console.WriteLine("Report found. Information:\n");
            report.ShowReport();
            return true;
        }
        return false;
    }

    private static Report FindReport(){
        Console.Write("Enter report name: ");
        string name = Console.ReadLine();
        foreach(Report report in Reports){
            if(report.Name == name){return report;}
        }
        Console.Write($"Report not found under '{name}'. Search again? (y/n): ");
        string exitChoice = Console.ReadLine();
        if(exitChoice.ToLower() == "y"){FindReport();}
        return null;
    }

    private static void ShowItems(bool title = false){
        if(title == true){Console.WriteLine("Items\n");}
        foreach(ReaderItem item in Items){
            Console.WriteLine($"Name: {item.name}");
            Console.WriteLine($"Quantity: {item.quantity}");
            Console.WriteLine($"Type: {item.type}");
            Console.WriteLine($"Store room: {item.storeRoom.Name}");
            switch(item.type){
                case "food":
                    Console.WriteLine($"Expiration Date: {item.date}");
                    break;
                case "document":
                    Console.WriteLine($"Effective Date: {item.date}");
                    Console.WriteLine($"Purpose: {item.docPurpose}");
                    break;
                case "clothing":
                    Console.WriteLine($"Style: {item.ClStyle}");
                    Console.WriteLine($"Size: {item.ClSize}");
                    break;
            }
            Console.WriteLine($"Assigned Person: {item.person.Name}");
        }
    }
    public static void ShowFamily(bool title = false){
        if(title == true){Console.WriteLine("Family\n");}
        foreach(ReaderPerson person in Family){
            Console.WriteLine($"Name: {person.name}");
            Console.WriteLine($"Age: {person.age}");
            Console.WriteLine($"Gender: {person.gender}");
            Console.WriteLine($"Height: {person.height}");
            Console.WriteLine($"Weight: {person.weight}");
            Console.WriteLine("\nClothing information:\n");
            Console.WriteLine($"Size: {person.size}");
        }
    }

    public static void ShowAll(){
        ShowItems();
        ShowFamily();
    }

    public void ShowReport(){
        switch(Type){
            case "full":
                ShowItems(title:true);
                ShowFamily(title:true);
                break;
            case "items":
                ShowItems();
                break;
            case "family":
                ShowFamily();
                break;
            case "family+":
                break;
            case "storage rooms":
                break;
            case "needs":
                break;
            default:
                throw new ArgumentException("Invalid Option");
        }
    }
}