public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int PointsPerEvent { get; set; }
    public int BonusPoints { get; set; }
    public int CompletedCount { get; set; }

    public ChecklistGoal(string name, string description, int targetCount, int pointsPerEvent, int bonusPoints) : base(name, description)
    {
        TargetCount = targetCount;
        PointsPerEvent = pointsPerEvent;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        CompletedCount++;
        if (CompletedCount >= TargetCount)
        {
            Completed = true;
            return PointsPerEvent * TargetCount + BonusPoints;
        }
        return PointsPerEvent;
    }
}