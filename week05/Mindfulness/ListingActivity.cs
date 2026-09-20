using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Length)];

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine();

        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items.");

        DisplayEndingMessage();
    }
}