using System;

class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public virtual void StartActivity(int duration)
    {
        Console.WriteLine($"\nStarting {name} activity.");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds.");
    }

    public virtual void EndActivity(int duration)
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed another {duration} seconds of your {name} activity.");
    }

    protected void GetReady(int seconds)
    {
        Console.WriteLine("Get Ready...");
        Spinner(seconds);
    }

    protected void Spinner(int seconds)
    {
        char[] spinnerChars = { '-', '\\', '|', '/' };
        for (int i = 0; i < seconds; i++)
        {
            foreach (char c in spinnerChars)
            {
                Console.Write($"\r{c} ");
                System.Threading.Thread.Sleep(100);
            }
        }
        Console.Write("\r   \r");
    }
}