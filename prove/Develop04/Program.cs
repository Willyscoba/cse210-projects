using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Mindfulness App!\n");
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Welcome to the Breathing Activity.");

                Console.WriteLine("This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.");

                Console.Write("Enter duration (in seconds) for your Breathing Activity: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.StartActivity(duration);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Welcome to the Reflecting Activity.");

                Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

                Console.Write("Enter duration (in seconds) for your Reflecting Activity: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.StartActivity(duration);
            }
            else if (choice == "3")
            {
                Console.WriteLine("Welcome to the Listing Activity.");

                Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

                Console.Write("Enter duration (in seconds) for your Listing Activity: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.StartActivity(duration);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using Mindfulness App. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            }
        }
    }
}