public class Resume{
    public string _name;
    public List<Job> _jobs;
    
    public void Display(){
        Console.WriteLine($"Name: {_name}\nJobs:");
        foreach(Job job in _jobs){
            Console.WriteLine($"{job._jobTitle} ({job._company}) {job._startYear}-{job._endYear}");
        }
    }
}