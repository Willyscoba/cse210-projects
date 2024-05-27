public class SimpleGoal : Goal
{
    public int Points { get; set; }

    public SimpleGoal(string name, string description, int points) : base(name, description)
    {
        Points = points;
    }

    public override int RecordEvent()
    {
        Completed = true;
        return Points;
    }
}