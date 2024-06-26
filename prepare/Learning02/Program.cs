using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Software Engineer", "Mirosoft", "2019", "2022");
        Job job2 = new Job("Manager", "Apple", "2022", "2023");

        job1.Display();
        job2.Display();

        Resume myResume = new Resume("Williams Okorie");
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        myResume.Display();
    }
}