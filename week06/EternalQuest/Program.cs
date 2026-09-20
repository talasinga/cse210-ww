using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        /*
         * Creativity / exceeding requirements:
         *
         * 1. The program includes a level system based on the user's score.
         * 2. The program displays achievement messages when the user reaches
         *    certain score levels.
         * 3. The program uses polymorphism by storing all goal types in
         *    one List<Goal> and calling overridden methods.
         * 4. The program saves and loads both goals and the current score.
         */

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine();
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Level: {GetLevel()}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                )
            );
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            Pause();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Goal created successfully!");
        Pause();
    }

    static void ListGoals()
    {
        Console.Clear();

        Console.WriteLine("Your Goals:");
        Console.WriteLine();

        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Total Score: {score}");
        Console.WriteLine($"Current Level: {GetLevel()}");

        Pause();
    }

    static void RecordEvent()
    {
        Console.Clear();

        if (goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            Pause();
            return;
        }

        Console.WriteLine("Choose a goal to record:");
        Console.WriteLine();

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.WriteLine();
        Console.Write("Which goal did you accomplish? ");

        int choice;

        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid choice.");
            Pause();
            return;
        }

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            Pause();
            return;
        }

        Goal selectedGoal = goals[choice - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine();
            Console.WriteLine("That goal is already complete.");
            Pause();
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        score += earnedPoints;

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You earned {earnedPoints} points.");
        Console.WriteLine($"Your new score is {score}.");
        Console.WriteLine($"Your current level is {GetLevel()}.");

        ShowAchievement();

        Pause();
    }

    static void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals saved successfully.");
        Pause();
    }

    static void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Pause();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            Pause();
            return;
        }

        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool complete = bool.Parse(parts[4]);

                goals.Add(
                    new SimpleGoal(
                        name,
                        description,
                        points,
                        complete
                    )
                );
            }
            else if (parts[0] == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                goals.Add(
                    new EternalGoal(
                        name,
                        description,
                        points
                    )
                );
            }
            else if (parts[0] == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus,
                        amountCompleted
                    )
                );
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals loaded successfully.");
        Console.WriteLine($"Current score: {score}");

        Pause();
    }

    static int GetLevel()
    {
        if (score >= 5000)
        {
            return 5;
        }

        if (score >= 2500)
        {
            return 4;
        }

        if (score >= 1000)
        {
            return 3;
        }

        if (score >= 500)
        {
            return 2;
        }

        return 1;
    }

    static void ShowAchievement()
    {
        if (score >= 5000)
        {
            Console.WriteLine("Achievement unlocked: Eternal Champion!");
        }
        else if (score >= 2500)
        {
            Console.WriteLine("Achievement unlocked: Faithful Quest!");
        }
        else if (score >= 1000)
        {
            Console.WriteLine("Achievement unlocked: Growing Strong!");
        }
        else if (score >= 500)
        {
            Console.WriteLine("Achievement unlocked: First Major Milestone!");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}