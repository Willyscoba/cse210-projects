using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C# Programming", "Williams Okorie", 600);
        video1.AddComment("Jacob", "Great video, very educative!");
        video1.AddComment("Jerry", "I learned a lot from this, thanks!");
        video1.AddComment("Vera", "Could you please explain more about interface?");
        video1.AddComment("Josh", "Wonderful content, I'm impressed.");
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programing Basics", "Pop Bright", 720);
        video2.AddComment("David", "This was a bit too fast for me.");
        video2.AddComment("Joe", "Awesome content, looking forward to more!");
        video2.AddComment("Frank", "please could you explain more on the benefits of Version Control System?");
        video2.AddComment("Chisom", "The best video I have seen this year, very informative!");
        videos.Add(video2);

        Video video3 = new Video("Web Development Tutorial", "Jeremiah Kalu", 480);
        video3.AddComment("Favour", "I'm struggling with CSS, any tips?");
        video3.AddComment("Olise", "What a clear explanations, well understood, thanks!");
        video3.AddComment("Ifeanyi", "Love this video, I have learnt a lot.");
        video3.AddComment("Simeon", "Please trow more light!");
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + "seconds");
            Console.WriteLine("Number of Comments: " + video.NumComments());
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine("> " + comment.CommenterName + ": " + comment.CommentText);
            }
            Console.WriteLine();
        }
    }  
}