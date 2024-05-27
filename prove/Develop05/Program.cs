class Program
{
    static void Main(string[] args)
    {
       EternalQuest eternalQuest = new EternalQuest();
        Console.WriteLine("You have 0 points.");

        int choice;
        do
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Events");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        eternalQuest.CreateGoal();
                        break;
                    case 2:
                        Console.WriteLine("Your goals are:");
                        eternalQuest.DisplayGoals();
                        break;
                    case 3:
                        Console.Write("Enter filename to save goals: ");
                        string saveFilename = Console.ReadLine();
                        eternalQuest.SaveGoalsAsText(saveFilename);
                        break;
                    case 4:
                        Console.Write("Enter filename to load goals: ");
                        string loadFilename = Console.ReadLine();
                        eternalQuest.LoadGoalsFromText(loadFilename);
                        break;
                    case 5:
                        eternalQuest.RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 6);
    }
}