class ReflectionActivity : Activity
{
    private string[] reflectionPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void StartActivity(int duration)
    {
        base.StartActivity(duration);
        GetReady(15);
        Reflect(duration);
        base.EndActivity(duration);
    }

    private void Reflect(int duration)
    {
        Random rand = new Random();
        int count = duration / 15; // This calculate the number of reflection cycles based on duration
        for (int i = 0; i < count; i++)
        {
            string prompt = reflectionPrompts[rand.Next(reflectionPrompts.Length)];
            Console.WriteLine(prompt);
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Spinner(5);
            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Spinner(15); // Display each question for 15 seconds
            }
        }
    }
}