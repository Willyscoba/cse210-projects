using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
class PromptJournal
{
    public string Prompt { get; set; }
    public string Response { get; set;}
    public string Date { get; set; }

    public PromptJournal(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class JournalManager
{
    private List<PromptJournal> journalEntries;
    private System.Timers.Timer reminderTimer;

    public JournalManager()
    {
        journalEntries = new List<PromptJournal>();
        SetupReminder();
    }

    private void SetupReminder()
    {
        reminderTimer = new System.Timers.Timer();
        reminderTimer.Interval = TimeSpan.FromSeconds(30).TotalMilliseconds;
        reminderTimer.Elapsed += ReminderElapsed;
        reminderTimer.AutoReset = true;
        reminderTimer.Start();
    }
    private void ReminderElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Don't forget to write in your journal today!");
    }
    public void WriteNewEntry(string[] prompts)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("MM/dd/yyyy");

        PromptJournal entry = new PromptJournal(prompt, response, date);
        journalEntries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }
    public void DisplayJournal()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }
        foreach (PromptJournal entry in journalEntries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournalToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (PromptJournal entry in journalEntries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving Journal: {ex.Message}");
        }
    }

    public void LoadJournalFromFile(string filename)
    {
        try
        {
            string[] line = File.ReadAllLines(filename);
            journalEntries.Clear();

            foreach (string lines in line)
            {
                string[] parts = lines.Split('|');
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                PromptJournal entry = new PromptJournal(prompt, response, date);
                journalEntries.Add(entry);
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        JournalManager manager = new JournalManager();

        while (true)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    manager.WriteNewEntry(prompts);
                    break;
                case "2":
                    manager.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    manager.SaveJournalToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    manager.LoadJournalFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. please try again.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
