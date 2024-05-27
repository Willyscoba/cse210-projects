public class EternalGoal : Goal
{
    public int Points { get; set; }

    public EternalGoal(string name, string description, int points) : base(name, description)
    {
        
        Points = points;
    }

    public override int RecordEvent()
    {
        Completed = true;
        return Points;
    }
}