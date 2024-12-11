using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        TimeSpan time = TimeSpan.FromSeconds(Length);
        string lengthFormatted = time.ToString(@"mm\:ss");
        string videoInfo = $"Title: {Title}\nAuthor: {Author}\nLength: {lengthFormatted}\nNumber of Comments: {GetNumberOfComments()}";
        string commentsInfo = string.Join("\n", Comments);
        return $"{videoInfo}\nComments:\n{commentsInfo}\n";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C# in 10 Minutes", "Code Academy", 600);
        Video video2 = new Video("Top 10 Programming Languages 2024", "Tech Talks", 720);
        Video video3 = new Video("Understanding AI Basics", "AI Experts", 900);

        video1.AddComment(new Comment("Alice", "This was really helpful!"));
        video1.AddComment(new Comment("Bob", "Thanks for the quick overview."));
        video1.AddComment(new Comment("Charlie", "Can you do one on JavaScript?"));

        video2.AddComment(new Comment("Dave", "Great list, but what about Ruby?"));
        video2.AddComment(new Comment("Eve", "Python is definitely my favorite."));
        video2.AddComment(new Comment("Frank", "Surprised C++ is still so popular."));

        video3.AddComment(new Comment("Grace", "AI is so fascinating!"));
        video3.AddComment(new Comment("Hank", "I learned a lot, thank you."));
        video3.AddComment(new Comment("Ivy", "Can you recommend more resources?"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine(video);
        }
    }
}