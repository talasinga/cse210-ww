using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity / Exceeding Requirements:
        // I added several additional journal prompts so the user has
        // more variety when writing entries. I also added helpful
        // messages when the journal is empty, when a file cannot be
        // found, and when saving/loading is completed.

        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                journal.WriteEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thank you for using the Journal Program!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1-5.");
            }
        }
    }
}