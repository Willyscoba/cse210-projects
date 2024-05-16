using System;

public class WritingAssignment : Assignment
{
    private string _writingPrompt;

    public WritingAssignment(string studentName, string topic, string writingPrompt)
        : base(studentName, topic)
    {
        _writingPrompt = writingPrompt;
    }

    public string GetWritingInformation()
    {
        return $"{_writingPrompt} by {GetStudentName()}";
    }
    public override string GetSummary()
    {
        return base.GetSummary();
    }
   
}