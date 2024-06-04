using System;

class Program
{
    static void Main(string[] args)
    {
        Running runningActivity = new Running("07 June 2024", 60, 3.0);
        Biking bikingActivity = new Biking("20 June 2024", 45, 12.0);
        Swimming swimmingActivity = new Swimming("01 July 2024", 30, 10);

        Activity[] activities = { runningActivity, bikingActivity, swimmingActivity };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}