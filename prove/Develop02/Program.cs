using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Electrician";
        job1._company = "Markivo Electrical services and supplies";
        job1._startYear = 2014;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Service Crew";
        job2._company = "Utah Valley University - Costa Vida";
        job2._startYear = 09-2022;
        job2._endYear = 11-2022;

        Resume myResume = new Resume();
        myResume._name = "Mark Anthony Visitacion";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}