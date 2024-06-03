class WritingAssignment : Assignment {
    private string _title;

    public string GetWritingInformation(){
        string summary = base.GetSummary();
        return $"{summary}\n{_title}";
    }
    public WritingAssignment(string studentName,string topic, string title) : base(studentName,topic){
        _title = title;
    }
}