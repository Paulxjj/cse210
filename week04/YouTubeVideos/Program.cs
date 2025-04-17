using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create and add videos with comments
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));

        Video video2 = new Video("Top 10 Programming Tips", "TechGuru", 900);
        video2.AddComment(new Comment("Dave", "Awesome tips!"));
        video2.AddComment(new Comment("Eve", "Tip #3 was a game changer."));
        video2.AddComment(new Comment("Frank", "Thanks for sharing!"));

        Video video3 = new Video("Understanding OOP Concepts", "DevSimplified", 1200);
        video3.AddComment(new Comment("Grace", "Clear and concise explanation."));
        video3.AddComment(new Comment("Hank", "This made OOP so much easier to understand."));
        video3.AddComment(new Comment("Ivy", "Looking forward to more videos!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}