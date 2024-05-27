public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public abstract int RecordEvent();

    protected Goal(string name, string description)
    {
        Name = name;
        Description = description;
    }
}