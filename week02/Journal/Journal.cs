using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new I learned today?",
        "What is something I am grateful for today?",
        "What made me smile today?",
        "What is one goal I want to accomplish tomorrow?"
    };

    public void WriteEntry()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");

        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry(date, prompt, response);

        _entries.Add(newEntry);

        Console.WriteLine();
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayAll()
    {
        Console.WriteLine();

        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        Console.WriteLine("Your Journal:");
        Console.WriteLine("----------------------------------------");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveFormat());
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length >= 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry(date, prompt, response);

                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully!");
    }
}