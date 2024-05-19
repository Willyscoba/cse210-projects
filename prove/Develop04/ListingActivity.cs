class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void StartActivity(int duration)
    {
        base.StartActivity(duration);
        GetReady(10);
        ListItems(duration);
        base.EndActivity(duration);
    }

    private void ListItems(int duration)
    {
        Random rand = new Random();
        string prompt = listingPrompts[rand.Next(listingPrompts.Length)];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine(prompt);
        Spinner(duration);
        Console.WriteLine("\nStart listing. Press Enter after each item. Press Enter twice to finish.");
        int count = 0;
        while (true)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }
            count++;
        }
        Console.WriteLine($"\nYou listed {count} items.");
    }
}