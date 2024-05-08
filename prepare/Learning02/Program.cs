using System;
//job class and resume class (job as a object called within resume)
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = "2019";
        job1._endYear = "2022";

        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = "2022";
        job2._endYear = "2023";
        job1.Display(); //uncommented for submission
        job2.Display(); //uncommented for submission

        Resume resume = new Resume();
        resume._name = "Nicholas Cutler";
        resume._jobs = [job1,job2];
        resume.Display();
    }
}