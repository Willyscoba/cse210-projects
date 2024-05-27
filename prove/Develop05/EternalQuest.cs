using System;
using System.Collections.Generic;
using System.IO;

public class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the Name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of your goal? ");

        string description = Console.ReadLine();
        switch (choice)
        {
            case 1:
                Console.Write("What is the points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                Console.Write("What is the points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the points associated with this goal? ");
                int pointsPerEvent = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, targetCount, pointsPerEvent, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("-------------------------");

        foreach (Goal goal in goals)
        {
            string completionStatus = goal.Completed ? "[X]" : "[ ]";
            string goalInfo = $"{completionStatus} {goal.Name}, ({goal.Description})";
            if (goal is ChecklistGoal checklistGoal)
            {
                goalInfo += $" -- You have completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount}";
            }
            Console.WriteLine(goalInfo);
        }

        Console.WriteLine("-------------------------");
    }

    public void RecordEvent()
    {
        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();
        foreach (Goal goal in goals)
        {
            if (goal.Name == goalName)
            {
                score += goal.RecordEvent();
                Console.WriteLine($"Event recorded for goal: {goalName}");
                Console.WriteLine($"Current score: {score}");
                CheckAndDisplayCongratulations();
                return;
            }
        }
        Console.WriteLine($"Goal '{goalName}' not found.");
    }

    public void CheckAndDisplayCongratulations()
    {
        if (AreAllGoalsCompleted())
        {
            Console.WriteLine("Congratulations! You have completed all your goals!");
        }
    }

    public bool AreAllGoalsCompleted()
    {
        foreach (Goal goal in goals)
        {
            if (!goal.Completed)
            {
                return false;
            }
        }
        return true;
    }
    public void SaveGoalsAsText(string filename)
    {
        try
        {
            using (StreamWriter write = new StreamWriter(filename))
            {
                foreach (Goal goal in goals)
                {
                    write.WriteLine($"Name: {goal.Name}");
                    write.WriteLine($"Description: {goal.Description}");
                    write.WriteLine($"Completed: {goal.Completed}");
                    if (goal is SimpleGoal simpleGoal)
                    {
                        write.WriteLine($"Type: Simple");
                        write.WriteLine($"Points: {simpleGoal.Points}");
                    }
                    else if (goal is EternalGoal eternalGoal)
                    {
                        write.WriteLine($"Type: Eternal Goal");
                        write.WriteLine($"Points: {eternalGoal.Points}");
                    }
                    else if (goal is ChecklistGoal checklistGoal)
                    {
                        write.WriteLine($"Type: Checklist");
                        write.WriteLine($"Target Count: {checklistGoal.TargetCount}");
                        write.WriteLine($"Points per Event: {checklistGoal.PointsPerEvent}");
                        write.WriteLine($"Bonus Points: {checklistGoal.BonusPoints}");
                        write.WriteLine($"Completed Count: {checklistGoal.CompletedCount}");
                    }
                    write.WriteLine();
                }
            }
            Console.WriteLine($"Goals saved to '{filename}' successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine($"Error: Failed to save goals to '{filename}'.");
        }
    }

    public void LoadGoalsFromText(string filename)
    {
        try
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                        continue;

                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = string.Join(':', parts, 1, parts.Length - 1).Trim();

                        switch (key)
                        {
                            case "Name":
                                string name = value;
                                string description = reader.ReadLine().Split(':')[1].Trim();
                                bool completed = bool.Parse(reader.ReadLine().Split(':')[1].Trim());

                                string type = reader.ReadLine().Split(':')[1].Trim();
                                int points = 0;
                                int targetCount = 0;
                                int pointsPerEvent = 0;
                                int bonusPoints = 0;
                                int completedCount = 0;

                                if (type == "Simple")
                                {
                                    points = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    goals.Add(new SimpleGoal(name, description, points));
                                }
                                else if (type == "Eternal Goal")
                                {
                                    points = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    goals.Add(new EternalGoal(name, description, points));
                                }
                                else if (type == "Checklist")
                                {
                                    targetCount = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    pointsPerEvent = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    bonusPoints = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    completedCount = int.Parse(reader.ReadLine().Split(':')[1].Trim());
                                    goals.Add(new ChecklistGoal(name, description, targetCount, pointsPerEvent, bonusPoints));
                                }
                                break;
                        }
                    }
                    else
                    {
                        // To handle unexpected line format
                    }
                }
            }
            Console.WriteLine($"Goals loaded from '{filename}' successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine($"Error: Failed to load goals from '{filename}'.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Error: Format error while parsing file '{filename}'.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"Error: Index out of range error while parsing file '{filename}'.");
        }
    }

    public void DisplayLoadedGoals()
    {
        Console.WriteLine("Loaded Goals:");
        Console.WriteLine("-------------------------");

        foreach (Goal goal in goals)
        {
            string completionStatus = goal.Completed ? "[X]" : "[ ]";
            string goalInfo = $"{completionStatus} {goal.Name}, ({goal.Description})";
            if (goal is ChecklistGoal checklistGoal)
            {
                goalInfo += $" -- You have completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount}";
            }
            Console.WriteLine(goalInfo);
        }

        Console.WriteLine("-------------------------");
    }

    public void LoadAndDisplayGoals(string filename)
    {
        LoadGoalsFromText(filename);
        DisplayLoadedGoals();
    }
}
