using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Lisa", 600);
        video1.AddComment(new Comment("John", "Thanks, this helped me a lot!"));
        video1.AddComment(new Comment("Emma", "Looks delicious 😋"));
        video1.AddComment(new Comment("Tom", "Simple and clear. Loved it."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("DIY Home Decor", "Crafty Anna", 900);
        video2.AddComment(new Comment("Sarah", "So creative, trying it this weekend!"));
        video2.AddComment(new Comment("Mike", "Where did you buy the materials?"));
        video2.AddComment(new Comment("Jessie", "Awesome, my room looks better now."));
        videos.Add(video2);
        // Video 3
        Video video3 = new Video("Workout Routine for Beginners", "FitMark", 1200);
        video3.AddComment(new Comment("James", "Great energy and clear steps."));
        video3.AddComment(new Comment("Linda", "Can we get a printable version?"));
        video3.AddComment(new Comment("Alex", "Love how motivating this is!"));
        videos.Add(video3);

        // Display each video info and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}