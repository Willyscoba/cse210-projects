class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }

    public int NumComments()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}