class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void StartActivity(int duration)
    {
        base.StartActivity(duration);
        GetReady(10);
        Breathe(duration);
        base.EndActivity(duration);
    }

    private void Breathe(int duration)
    {
        int count = duration / 10; // This calculate the number of breath cycles based on duration
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(5000); // 5 seconds for breathing in
            Console.WriteLine("Breathe out...");
            Thread.Sleep(5000); // 5 seconds for breathing out
        }
    }
}
