public class MathAssignment : Assignment
{
    private string _assignmentDetails;
    private string _problems;

    public MathAssignment(string studentName, string topic, string assignmentDetails, string problems)
        : base(studentName, topic)
    {
        _assignmentDetails = assignmentDetails;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section: {_assignmentDetails}. Problems: {_problems}";
    }
    public override string GetSummary()
    {
        return base.GetSummary();
    }
}