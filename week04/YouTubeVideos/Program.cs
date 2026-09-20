using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store all of the videos.
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learning C# for Beginners",
            "Code Academy",
            420
        );

        video1.AddComment(new Comment(
            "Talasinga",
            "This video helped me understand C# better."
        ));

        video1.AddComment(new Comment(
            "John",
            "Great explanation!"
        ));

        video1.AddComment(new Comment(
            "Malia",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "David",
            "Very helpful tutorial."
        ));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "How to Study Effectively",
            "Study Tips",
            360
        );

        video2.AddComment(new Comment(
            "Sione",
            "These study tips are really useful."
        ));

        video2.AddComment(new Comment(
            "Mary",
            "I will try these methods."
        ));

        video2.AddComment(new Comment(
            "Peter",
            "Thanks for sharing!"
        ));

        video2.AddComment(new Comment(
            "Ana",
            "This was very helpful."
        ));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Introduction to Programming",
            "Programming World",
            510
        );

        video3.AddComment(new Comment(
            "James",
            "Programming is becoming easier for me."
        ));

        video3.AddComment(new Comment(
            "Losa",
            "I really enjoyed this lesson."
        ));

        video3.AddComment(new Comment(
            "Mike",
            "The examples were easy to follow."
        ));

        video3.AddComment(new Comment(
            "Sarah",
            "Great introduction to programming."
        ));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Tips for Success in School",
            "Student Life",
            275
        );

        video4.AddComment(new Comment(
            "Daniel",
            "I agree with these tips."
        ));

        video4.AddComment(new Comment(
            "Grace",
            "This motivated me to work harder."
        ));

        video4.AddComment(new Comment(
            "Tina",
            "Very good advice."
        ));

        video4.AddComment(new Comment(
            "Joseph",
            "Thanks for making this video."
        ));

        videos.Add(video4);

        // Display every video and its comments.
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}