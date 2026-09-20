using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity / exceeding requirements:
        // This program uses a verse range (Proverbs 3:5-6), supports
        // random hiding of only words that are still visible, and
        // continues until the entire scripture is hidden.

        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text =
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to quit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}