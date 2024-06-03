class MathAssignment : Assignment{
    private string _textBookSection;
    private string _problems;

    public string GetHomeworkList(){
        string summary = base.GetSummary();
        return $"{summary}\nSection: {_textBookSection} Problems: {_problems}";
    }
    public MathAssignment(string studentName, string topic, string textBookSection, string problems) : base(studentName,topic){
        _textBookSection = textBookSection;
        _problems = problems;
    }
}